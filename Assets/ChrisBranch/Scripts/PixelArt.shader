Shader "Hidden/PixelArt"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _PixelRange("Pixel Size", float) = 64
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _PixelRange;

            fixed4 frag (v2f i) : SV_Target
            {


                float2 uv = i.uv;
                uv= floor(uv.xy  * _PixelRange) / _PixelRange;;
                
                 



                fixed4 col = tex2D(_MainTex, uv);

                //  Convertir a blanco y negro
                // float gray = dot(col.rgb, float3(0.299, 0.587, 0.114));
                // col.rgb = float3(gray, gray, gray);
                
                 // Mapeo de colores para simular aspecto NES
                 col.rgb = floor(col.rgb * 4) / 4;
                //  Aplicar dithering para un aspecto retro
                //  float noise = frac(uv.x * 8) * frac(uv.y * 8);
                //  col.rgb += noise * 0.05;
 

                // col.rgb = col.rgb ;
                return col;
            }
            ENDCG
        }
    }
}
