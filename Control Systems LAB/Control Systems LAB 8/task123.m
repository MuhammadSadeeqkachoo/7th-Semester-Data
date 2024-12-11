num=[1 1];  
denum=[1  3  80];  
[z p k]=tf2zp(num,denum)  
zplane(z,p);  



num=[1 1];  
denum=[1  -3  80];  
[z p k]=tf2zp(num,denum)  
zplane(z,p);  
 

num=[1 1];  
denum=[1  0  80];  
[z p k]=tf2zp(num,denum)  
zplane(z,p);  
