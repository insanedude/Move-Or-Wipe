Shader "Unlit/ColorFillShader"
{
    Properties
    {
        _BaseColor ("Base Color", Color) = (1, 1, 1, 1) // White color
        _FillColor ("Fill Color", Color) = (1, 0, 0, 1) // Red color
        _Fill ("Fill", Range(0, 1)) = 0.0 // Fill amount
        _Side ("Side", Range(0, 1)) = 0.0 // Side to shade (0-1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            fixed4 _BaseColor;
            fixed4 _FillColor;
            half _Fill;
            half _Side;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.normal = mul((float3x3)unity_ObjectToWorld, v.normal);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Determine if the normal direction matches the desired side
                float dotProduct = dot(i.normal, float3(0, 1, 0)); // Change to match the side you want to fill
                bool isSide = (_Side == 0.0 && dotProduct > 0) || (_Side == 1.0 && dotProduct < 0);

                // Determine color based on fill and side
                fixed4 color = _BaseColor;
                if (isSide)
                {
                    if (i.uv.y <= _Fill)
                    {
                        color = _FillColor;
                    }
                }

                return color;
            }
            ENDCG
        }
    }
}