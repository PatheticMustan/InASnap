Shader "Custom/FireAfterImageShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Strength ("Strength", float) = 0
        _DisplaceX ("Displace X", float) = 0
        _DisplaceY ("Displace Y", float) = 0
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

            float _Strength;
            float _DisplaceX;
            float _DisplaceY;

            bool compV3(fixed4 v, float b)
            {
                return v.x > b && v.y > b && v.z > b;
            }

            float2 hash2(float2 uv)
            {
                return sin(sin(float2(dot(uv, float2(32.57, -6.421)), dot(uv, float2(12.57, 26.421))) * 32.57) * 59.61);
            }

            float2 noise(float2 uv)
            {
                float2 i = floor(uv);
                float2 f = uv % 1;

                float2 a = hash2(i);
                float2 b = hash2(i + float2(1., 0.));
                float2 c = hash2(i + float2(0., 1.));
                float2 d = hash2(i + float2(1., 1.));

                float2 u = f * f * (3. - 2. * f);

                return lerp(a, b, u.x) +
                    (c - a) * u.y * (1.0 - u.x) +
                    (d - b) * u.x * u.y;
            }

            float2 fbm(float2 uv)
            {
                float a = .1, m = .5, s = 10., l = 1.2;
                float2 v = float2(0,0);
                for (int i = 0; i++ < 5;)
                {
                    v += noise(uv * s + _Time.y * .15) * a;
                    a *= m;
                    s *= l;

                }
                return v;
            }

            float2 fireDisplace(float2 uv, float2 dir, float d)
            {
                float c = .1 + abs(.5 - uv.x) * .8;
                return d * fbm(fbm(fbm(uv) * dir * c * 10.) * float2(1, 1)) * c * 1.5;
            }

            fixed4 clampGetTex(float2 uv) 
            {
                if (uv.x > 1 || uv.x < 0 || uv.y > 1 || uv.y < 0)
                    return fixed4(1, 1, 1, 1);
                return tex2D(_MainTex, uv);
            }


            fixed4 frag (v2f i) : SV_Target
            {
                //fixed4 col = tex2D(_MainTex, i.uv);
                
                //float2 uv = fragCoord / iResolution.xy;
                float2 d = float2(_DisplaceX, _DisplaceY), f = fireDisplace(i.uv, float2(.2, .2), _Strength);

            // Time varying pixel color
                fixed4 col = clampGetTex(i.uv + d + f);
                if (col.a <= .1) {
                    col.a = 0;
                }
                else if (!compV3(col, .9))
                {
                    col = fixed4(1, .8, .3, 1);
                }
                else {
           
                    col = tex2D(_MainTex, i.uv);
                    if (!compV3(col, .9))
                    {
                        col = fixed4(1, .6, .3, 1);
                    }
                    else {
                        col = clampGetTex(i.uv - d - f);
                        if (!compV3(col, .9))
                        {
                            col = fixed4(.6, .3, .9, 1);
                        }
                        else
                        {
                            col = fixed4(0, 0, 0, 0);//clampGetTex(i.uv);
                        }
                    }
                }
                //col = clampGetTex(i.uv);
                col.rgb *= col.a;
            // Output to screen
                //fragColor = vec4(col, 1.0);
                //UNITY_APPLY_FOG(i.fogCoord, col);

                return col;
            }
            ENDCG
        }
    }
}
