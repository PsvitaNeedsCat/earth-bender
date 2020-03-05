Shader "EarthBender/BlendWater"
{
	Properties
	{
		_Color("Color", Color) = (1, 1, 1, 1)
		_MainTex("Texture1", 2D) = "white"{}
		_MainTex2("Texture2", 2D) = "white"{}
		_Blend("Blend Value", Range(0, 1)) = 0.0
	}

		SubShader
		{
			Tags {"RenderType" = "Opaque"}
			LOD 200

			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows

		sampler2D _MainTex;
		sampler2D _MainTex2;

		struct Input
		{
			float2 uv_MainTex;
			float2 uv_MainTex2;
		};

		half _Blend;
		fixed4 _Color;

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = lerp(tex2D(_MainTex, IN.uv_MainTex), tex2D(_MainTex2, IN.uv_MainTex2), _Blend) * _Color;
			o.Albedo = c.rgb;
		}

		ENDCG
	}
			Fallback "Diffuse"
}