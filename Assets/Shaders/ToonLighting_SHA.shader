Shader "EarthBender/Soft Shading"
{
	Properties
	{
		[Header(DIFFUSE)]
		_Color("Base Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		[Space]
		[Header(SHADOWS)]
		_ShadowThresh("Shadow Threshold", Range(0, 2)) = 1
		_ShadowSmooth("Shadow Smoothness", Range(0.5, 1.5)) = 0.6
		[HDR]_ShadowColor("Shadow Color", Color) = (0, 0, 0, 1)
	}
		SubShader
		{
			Tags { "Queue" = "Transparent" "RenderType" = "Opaque" }
			LOD 200								//Level of Detail = 200

			CGPROGRAM
			#include "ToonCommon.cginc"
			#pragma surface surf Toon fullforwardshadows //alpha
			#pragma target 3.0

			half _ShadowThresh;
			half _ShadowSmooth;
			half3 _ShadowColor;

			sampler2D _MainTex;			//sample diffuse

			struct Input
			{
				float2 uv_MainTex;		//Input object UVs
				float3 viewDir;			//Grab view/camera direction
			};

			fixed4 _Color;				//Declare colour

			void surf(Input IN, inout SurfaceOutput o)
			{
				InitLightingToon(_ShadowThresh, _ShadowSmooth, _ShadowColor);
				o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _Color;		//Albedo = (diffuse, diffuse UVs) colour * colour chosen in inspector
			}
			ENDCG
		}
			FallBack "Diffuse"
}
