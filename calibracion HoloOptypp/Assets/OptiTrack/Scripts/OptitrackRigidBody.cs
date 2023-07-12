﻿/* 
Copyright © 2016 NaturalPoint Inc.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License. 
*/

using System;
using System.IO;
using System.Text;
using UnityEngine;


/// <summary>
/// Implements live tracking of streamed OptiTrack rigid body data onto an object.
/// </summary>
public class OptitrackRigidBody : MonoBehaviour
{

    [Tooltip("The object containing the OptiTrackStreamingClient script.")]
    public OptitrackStreamingClient StreamingClient;

    [Tooltip("The Streaming ID of the rigid body in Motive")]
    public Int32 RigidBodyId;

    [Tooltip("Subscribes to this asset when using Unicast streaming.")]
    public bool NetworkCompensation = true;
    
    [SerializeField]   
    public StringBuilder csv= new StringBuilder();
    
    string oldPosition = "0";
    string oldRotation = "0";
    public bool seguro=false;
    void Start()
    {
        // If the user didn't explicitly associate a client, find a suitable default.
        if ( this.StreamingClient == null )
        {
            this.StreamingClient = OptitrackStreamingClient.FindDefaultClient();

            // If we still couldn't find one, disable this component.
            if ( this.StreamingClient == null )
            {
                Debug.LogError( GetType().FullName + ": Streaming client not set, and no " + typeof( OptitrackStreamingClient ).FullName + " components found in scene; disabling this component.", this );
                this.enabled = false;
                return;
            }
        }

        this.StreamingClient.RegisterRigidBody( this, RigidBodyId );
    }


#if UNITY_2017_1_OR_NEWER
    void OnEnable()
    {
        Application.onBeforeRender += OnBeforeRender;
    }


    void OnDisable()
    {
        Application.onBeforeRender -= OnBeforeRender;
    }


    void OnBeforeRender()
    {
        UpdatePose();
    }
#endif


    void Update()
    {
        UpdatePose();
    }

/// <summary>
/// ESTE MÉTODO ES EL QUE DEBO ACTUALIZAR O DE ACÁ ES QUE DEBO SACAR LOS DATOS PARA GUARDARLOS EN EL CSV
/// </summary>
    void UpdatePose()
    {
        OptitrackRigidBodyState rbState = StreamingClient.GetLatestRigidBodyState( RigidBodyId, NetworkCompensation);
        if (rbState != null)
        {
            this.transform.localPosition = rbState.Pose.Position;
            this.transform.localRotation = rbState.Pose.Orientation;
            var newPosition = rbState.Pose.Position.ToString();
            var newRotation = rbState.Pose.Orientation.ToString();
            if ((oldPosition != newPosition || oldRotation != newRotation)&& seguro)// acá debería ir un seguro y cuando ese seguro sea false, deje de guardar
            {
                var newLine = string.Format("{0},{1}", newPosition, newRotation);
                csv.AppendLine(newLine);
                oldPosition = newPosition;
                oldRotation = newRotation;
            }
        }
    }


    public void CambiarSeguro()
    {
        Debug.Log("seguro ha cambiado a true");
        seguro = true;
    }

[ContextMenu("Guardar Csv")]
public void SaveCSV()
{
    if (gameObject.CompareTag("Artro")){
        File.WriteAllText(Application.dataPath+"/DATA_CSV/ArtroTxt.csv", csv.ToString());
    }
    
    if (gameObject.CompareTag("Palpa")){
        File.WriteAllText(Application.dataPath+"/DATA_CSV/PalpaTxt.csv", csv.ToString());
    }
}
}
