Shader "TEST/Texture3d"{
Properties{
//размер куба 2^d (максимальное значение координат xyz)
_d ("d",Integer) = 0
//координаты цветного куба в шейдере
_nx ("xn",Integer) = 1
_ny ("yn",Integer) = 1
_nz ("zn",Integer) = 1
//цвет куба с координатами в шейдере
_c("Example color", Color) = (1, 0, 0, 1)
//текстура геометрического shader куба
_MainTex ("Albedo (RGB)", 2D) = "white" {}
}
SubShader{
Pass {
CGPROGRAM
#pragma vertex vert
#pragma geometry geo
#pragma fragment frag
#pragma target 4.6

struct geometryOutput{
float4 pos:SV_POSITION;
float2 uv:TEXCOORD0;
int normal : NORMAL;
};
geometryOutput VertexOutput(float3 pos, float2 uv, int normal){
geometryOutput o;
//преобразует точку из пространства объекта в пространство отсечения камеры
o.pos = UnityObjectToClipPos(pos);
o.uv = uv;
o.normal = normal;
return o;
}
sampler2D _MainTex;
int _nx;
int _ny;
int _nz;
float _d;
fixed4 _c;
[maxvertexcount(36)]
void geo(triangle geometryOutput IN[3] : SV_POSITION, inout TriangleStream<geometryOutput> OutputStream){
geometryOutput o;
float3 pos = IN[0].pos;
float x = pow(2.0, _d);
//down
//нижний
OutputStream.Append(VertexOutput(x*float3(-1, -1, 1), float2(0, 1),0));
OutputStream.Append(VertexOutput(x*float3(-1, -1, -1), float2(0, 0),0));
OutputStream.Append(VertexOutput(x*float3(1, -1, -1), float2(1, 0),0));
//верхний
OutputStream.Append(VertexOutput(x*float3(1, -1, -1), float2(1, 0),0));
OutputStream.Append(VertexOutput(x*float3(-1, -1, 1), float2(0, 1),0));
OutputStream.Append(VertexOutput(x*float3(1, -1, 1), float2(1, 1),0));
//forward
//нижний
OutputStream.Append(VertexOutput(x*float3(1, -1, 1), float2(1, 0),1));
OutputStream.Append(VertexOutput(x*float3(1, 1, 1), float2(1, 1),1));
OutputStream.Append(VertexOutput(x*float3(-1, -1, 1), float2(0, 0),1));
//верхний
OutputStream.Append(VertexOutput(x*float3(-1, -1, 1), float2(0, 0),1));
OutputStream.Append(VertexOutput(x*float3(-1, 1, 1), float2(0, 1),1));
OutputStream.Append(VertexOutput(x*float3(1, 1, 1), float2(1, 1),1));
//right
//нижний
OutputStream.Append(VertexOutput(x*float3(1, 1, 1), float2(1, 1),2));
OutputStream.Append(VertexOutput(x*float3(1, -1,  1), float2(1, 0),2));
OutputStream.Append(VertexOutput(x*float3(1, -1, -1), float2(0, 0),2));
//верхний
OutputStream.Append(VertexOutput(x*float3(1, -1, -1), float2(0, 0),2));
OutputStream.Append(VertexOutput(x*float3(1, 1, 1), float2(1, 1),2));
OutputStream.Append(VertexOutput(x*float3(1, 1, -1), float2(0, 1),2));
//back
//нижний
OutputStream.Append(VertexOutput(x*float3(1, 1, -1), float2(1, 1),3));
OutputStream.Append(VertexOutput(x*float3(1, -1, -1), float2(1, 0),3));
OutputStream.Append(VertexOutput(x*float3(-1, -1, -1), float2(0, 0),3));
//верхний
OutputStream.Append(VertexOutput(x*float3(-1, -1, -1), float2(0, 0),3));
OutputStream.Append(VertexOutput(x*float3(1, 1, -1), float2(1, 1),3));
OutputStream.Append(VertexOutput(x*float3(-1, 1, -1), float2(0, 1),3));
//left
//нижний
OutputStream.Append(VertexOutput(x*float3(-1, 1, -1), float2(0, 1),4));
OutputStream.Append(VertexOutput(x*float3(-1, -1, -1), float2(0, 0),4));
OutputStream.Append(VertexOutput(x*float3(-1, -1, 1), float2(1, 0),4));
//верхний
OutputStream.Append(VertexOutput(x*float3(-1, -1, 1), float2(1, 0),4));
OutputStream.Append(VertexOutput(x*float3(-1, 1, -1), float2(0, 1),4));
OutputStream.Append(VertexOutput(x*float3(-1, 1, 1), float2(1, 1),4));
//up
//верхний
OutputStream.Append(VertexOutput(x*float3(-1, 1, 1), float2(0, 1),5));
OutputStream.Append(VertexOutput(x*float3(1, 1, 1), float2(1, 1),5));
OutputStream.Append(VertexOutput(x*float3(-1, 1, -1), float2(0, 0),5));
//нижний
OutputStream.Append(VertexOutput(x*float3(-1, 1, -1), float2(0, 0),5));
OutputStream.Append(VertexOutput(x*float3(1, 1, -1), float2(1, 0),5));          
OutputStream.Append(VertexOutput(x*float3(1, 1, 1), float2(1, 1),5));        
}

float4 vert(float4 vertex : POSITION) : SV_POSITION{
return UnityObjectToClipPos(vertex);
}
     
int color_cube(geometryOutput i){
//1 2 4 8 16
int N=(int)pow(2.0, _d);
//100-1
//200-2
//400-3
//800-4          
int max=(int)N*100-1;
//смещение
float D=1/(N*100.0);
int x1,y1,z1;

switch (i.normal){
case 0://down
x1=i.uv.x>_nx*D&i.uv.x<_nx*D+D?1:0;
z1=i.uv.y>_nz*D&i.uv.y<_nz*D+D?1:0;
y1=_ny==0?1:0;
if (x1+y1+z1==3) return 1;
break;
case 1://forward
x1=i.uv.x>_nx*D&i.uv.x<_nx*D+D?1:0;
y1=i.uv.y>_ny*D&i.uv.y<_ny*D+D?1:0;
z1=_nz==max?1:0;
if (x1+y1+z1==3) return 1;
break;
case 2://right
z1=i.uv.x>_nz*D&i.uv.x<_nz*D+D?1:0;
y1=i.uv.y>_ny*D&i.uv.y<_ny*D+D?1:0;
x1=_nx==max?1:0;
if (x1+y1+z1==3) return 1;
break;
case 3://back
x1=i.uv.x>_nx*D&i.uv.x<_nx*D+D?1:0;
y1=i.uv.y>_ny*D&i.uv.y<_ny*D+D?1:0;
z1=_nz==0?1:0;
if (x1+y1+z1==3) return 1;
break;
case 4://left
z1=i.uv.x>_nz*D&i.uv.x<_nz*D+D?1:0;
y1=i.uv.y>_ny*D&i.uv.y<_ny*D+D?1:0;
x1=_nx==0?1:0;
if (x1+y1+z1==3) return 1;
break;
case 5://up
x1=i.uv.x>_nx*D&i.uv.x<_nx*D+D?1:0;
z1=i.uv.y>_nz*D&i.uv.y<_nz*D+D?1:0;
y1=_ny==max?1:0;
if (x1+y1+z1==3) return 1;
break;
}
return 0;
}

float4 frag(geometryOutput i) : SV_Target{
return color_cube(i)==1?_c:tex2D(_MainTex,i.uv);
}
ENDCG
}
}
FallBack "Diffuse"
}