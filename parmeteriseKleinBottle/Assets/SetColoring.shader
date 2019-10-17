Shader "Custom/SetColoring"{
	Properties {
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		//_FourDCoordinatesAtStart ("FourDCoords", Vector) = (0,0,0,1)
		//could also have for 4d position where color of sphere changes depending on updated 4d position in space
		//_BallColorID ("BallColorID" , Float) = 0.0
		//_RandColors("RandColors", Vector) = (0,0,0,0)
        _Colours("Colours", Vector) = (0,0,0,0)//even though float3 still needs 4 entries when initialising
		
	}
	SubShader {
     //Tags {"Queue"="Transparent" "RenderType"="Transparent" }
	 Tags { "RenderType"="Opaque" }
     CGPROGRAM
     #pragma surface surf Lambert
	 //#pragma surface surf Standard fullforwardshadows alpha:fade
     #pragma target 3.0

    	

	 //uniform float4 _FourDCoordinatesAtStart;
	 //uniform float _BallColorID;
	 uniform float3 _Colours;
	 //uniform float3 _RandColors;
     //uniform float _DirectionID;

	 //half _Metallic;

     struct Input {
         float4 color : COLOR;
     };
     void surf (Input IN, inout SurfaceOutputStandard o) {
	 

		//o.Albedo.rgb = _FourDCoordinatesAtStart.rgb * 0.5 + 0.5; //fix later for unique colors (currently 2 balls with same color)
		
		//o.Albedo = _RandColors;
		
        o.Albedo = _Colours;
        o.Albedo.r = 1;
        
		o.Alpha = 1;
			
     }
     ENDCG
    }
    Fallback "Diffuse"
}
