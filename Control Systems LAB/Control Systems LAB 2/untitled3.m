num=  [10];  
deno=  [1  2  20];  
t  =  0:0.01:10;  
h=tf  (num, deno);  
u=sin  (t);  
lsim  (h,u,t) 