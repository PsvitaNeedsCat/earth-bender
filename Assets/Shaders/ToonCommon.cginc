//SHADE TUTORIAL FROM MANUELA MALASAÑA
#ifndef TOON_COMMON_LIBRARY_INCLUDED	//if not defined
#define TOON_COMMON_LIBRARY_INCLUDED	//define library

#include "UnityCG.cginc"

#define White half3(1, 1, 1)
#define Black half3(0, 0, 0)

half _ToonThreshold;
half _ToonSmoothness;
half3 _ToonShadowColor;

void InitLightingToon(half threshold, half smoothness, half3 shadowColor)
{
	_ToonThreshold = threshold;
	_ToonSmoothness = smoothness;
	_ToonShadowColor = shadowColor;
}

half4 LightingToon(SurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
{
	half d = pow(dot(s.Normal, lightDir) * 0.5 + 0.5, _ToonThreshold);
	half shadow = smoothstep(0.5, _ToonSmoothness, d);
	half3 shadowColor = lerp(_ToonShadowColor, half3(1, 1, 1), shadow);
	half4 c;
	c.rgb = s.Albedo * _LightColor0.rgb * atten * shadowColor;
	c.a = s.Alpha;
	return c;
}

#endif									//end if statement