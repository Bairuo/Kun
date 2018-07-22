

Shader "Custom/BlackWhiteEffect"
{
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_Degree("Degree", Range(0.0, 1.0)) = 1.0
	}

	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			fixed _Degree;

			fixed4 frag(v2f_img i) : SV_Target
			{
				fixed4 renderTex = tex2D(_MainTex, i.uv);

				float luminosity = 0.299 * renderTex.r + 0.587 * renderTex.g + 0.114 * renderTex.b;

				fixed4 col = lerp(renderTex, luminosity, _Degree);

				return col;
			}
			ENDCG
		}
	}
	Fallback off
}
