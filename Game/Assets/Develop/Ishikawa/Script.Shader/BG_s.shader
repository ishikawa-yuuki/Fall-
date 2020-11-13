Shader "Unlit/BG_s"
{
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work


            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };



            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 tex = i.uv;
               fixed4 blue = fixed4(0 + tex.y / 3, 120 / 255.0 + tex.y / 1.2,     1 , 1);
               fixed4 white = fixed4(0 + tex.y / 2, 180 / 255.0 + tex.y,         1 , 1);
               fixed4 white_1 = fixed4(180 / 255.0, 250 / 255.0,    1 , 1);
               fixed len = distance(i.uv, fixed2(0.65,0.5)) - _Time;
               if (step(0.8, sin(len * 20)))
               {
                   return lerp(blue, white,(smoothstep(0.8,0.95, sin(len * 20))));
               }
               if (step(0.85, sin(len * 25)))
               {
                   return lerp(blue, white_1, (smoothstep(0.85, 0.95,sin(len * 25))));
               }
               return blue;
            }
            ENDCG
        }
    }
}
