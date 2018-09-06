Shader "Custom/Shake" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader {
        Tags { "Queue"="Transparent" }
        LOD 200
        
        CGPROGRAM
        // サーフェスシェーダ(surf)と頂点シェーダの使用(vert)
        #pragma surface surf Lambert vertex:vert Standard alpha:fade
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input {
            float2 uv_MainTex;
        };
        //----------------------------------------------------------------------------
        // 頂点シェーダの操作
        // ここでモデルの１頂点それぞれに対して処理を行う
        // v.vertex = 頂点の座標
        void vert(inout appdata_full v, out Input o )
        {
            UNITY_INITIALIZE_OUTPUT(Input, o);
            //float amp = 0.5*sin(_Time*100 + v.vertex.x * 100);
            //v.vertex.xyz = float3(v.vertex.x, v.vertex.y+amp, v.vertex.z);  
            //float amp = 0.5*sin(_Time*100/* + v.vertex.y * 100*/);          
            float amp = 0.5*sin(_Time*30) * v.vertex.z;          
            v.vertex.xyz = float3(v.vertex.x + amp, v.vertex.y, v.vertex.z);            
            //v.normal = normalize(float3(v.normal.x+offset_, v.normal.y, v.normal.z));
        }
        //-----------------------------------------------------------------------------
        // サーフェスシェーダの操作
        void surf (Input IN, inout SurfaceOutput o) {
            // cにテクスチャの情報を取り出している
            // つまりそのままo(各ピクセル)にテクスチャの色情報を渡している
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
            //o.Alpha = (c.r*0.3 + c.g*0.6 + c.b*0.1 > 0.9) ? 1 : 0.0;
        }
        ENDCG
    }
    FallBack "Diffuse"
}