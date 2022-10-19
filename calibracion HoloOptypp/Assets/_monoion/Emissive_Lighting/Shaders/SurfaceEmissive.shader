// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "_monoion/_SimpleSurfaceEmissive"
{
	Properties
	{
		_AOAmount("AO Amount", Range( 0 , 1)) = 0
		[HDR]_EmissiveColour("Emissive Colour", Color) = (1.000069,0.1568736,0,0)
		_DeSaturation("DeSaturation", Range( 0 , 1)) = 0
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float4 vertexColor : COLOR;
		};

		uniform float4 _EmissiveColour;
		uniform float _AOAmount;
		uniform float _DeSaturation;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float4 temp_output_12_0_g4717 = _EmissiveColour;
			float4 lerpResult9_g4717 = lerp( float4(0,0,0,0) , temp_output_12_0_g4717 , ( 1.0 - ( ( 1.0 - ( 1 * i.vertexColor.r ) ) * _AOAmount ) ));
			float3 desaturateInitialColor8 = lerpResult9_g4717.xyz;
			float desaturateDot8 = dot( desaturateInitialColor8, float3( 0.299, 0.587, 0.114 ));
			float3 desaturateVar8 = lerp( desaturateInitialColor8, desaturateDot8.xxx, _DeSaturation );
			o.Emission = desaturateVar8;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=16900
1927;7;1906;1045;1444.681;1458.847;2.604136;True;True
Node;AmplifyShaderEditor.CommentaryNode;1;-1017.801,404.0687;Float;False;475;263;Comment;2;3;2;248;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;4;-478.3081,343.1899;Float;False;354.9219;376.4307;Comment;2;6;5;Add Emissive AO;1,1,1,1;0;0
Node;AmplifyShaderEditor.VertexColorNode;7;-1150.959,794.8615;Float;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;2;-969.8016,452.0686;Float;False;Property;_EmissiveColour;Emissive Colour;3;1;[HDR];Create;True;0;0;False;0;1.000069,0.1568736,0,0;0.9882353,0.4317168,0,0;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;6;-425.3862,393.1899;Float;False;Property;_AOAmount;AO Amount;0;0;Create;True;0;0;False;0;0;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;5;-428.3081,466.6201;Float;True;_Emissive AO;1;;4717;500da12fa87be02498bd07253c8cd9e7;0;3;13;FLOAT;0;False;12;FLOAT4;0,0,0,0;False;11;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RangedFloatNode;9;-73.0071,346.0749;Float;False;Property;_DeSaturation;DeSaturation;4;0;Create;True;0;0;False;0;0;0.129;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3;-713.8009,532.0687;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.DesaturateOpNode;8;127.1929,461.7747;Float;False;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;520,393.8997;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;_monoion/_SimpleSurfaceEmissive;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;5;13;6;0
WireConnection;5;12;2;0
WireConnection;5;11;7;0
WireConnection;3;0;2;0
WireConnection;8;0;5;0
WireConnection;8;1;9;0
WireConnection;0;2;8;0
ASEEND*/
//CHKSM=BB7301E00F64F88D8A3E4F45FCD9CED5D954BCF2