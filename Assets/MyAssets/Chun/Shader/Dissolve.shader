// Upgrade NOTE: upgraded instancing buffer 'Props' to new syntax.

Shader "Custom/disolve" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_bloomColor("BloomColor",Color) = (1,1,1,1)
		_bloomEmissionColor("BloomEmissionColor",Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_DisolveTex("DisolveTex (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_Threshold("Threshold", Range(0,1)) = 0.0
	}
		SubShader{
			Tags { "RenderType" = "Opaque" }
			LOD 200

			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows
			#pragma target 3.0

			sampler2D _MainTex;
			sampler2D _DisolveTex;

			struct Input {
				float2 uv_MainTex;
			};

			half _Glossiness;
			half _Metallic;
			half _Threshold;
			fixed4 _Color;
			fixed4 _bloomColor;
			fixed4 _bloomEmissionColor;

			UNITY_INSTANCING_BUFFER_START(Props)
			UNITY_INSTANCING_BUFFER_END(Props)

			void surf(Input IN, inout SurfaceOutputStandard o) {
				// Albedo comes from a texture tinted by color
				fixed4 m = tex2D(_DisolveTex, IN.uv_MainTex);
				half g = m.r * 0.2 + m.g * 0.7 + m.b * 0.1;
				

				fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
				o.Albedo = c.rgb;
				// Metallic and smoothness come from slider variables
				o.Metallic = _Metallic;
				o.Smoothness = _Glossiness;
				o.Alpha = c.a; 
				if (g < _Threshold + 0.05f) {
					o.Albedo = _bloomColor;
					o.Emission = _bloomEmissionColor.rgb;
				}
				if (g < _Threshold) {
					discard;
				}
			}
			ENDCG
		}
			FallBack "Diffuse"
}