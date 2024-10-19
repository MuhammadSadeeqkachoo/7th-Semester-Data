num = [10];
deno = [1 2 20];
t = 0:0.01:10;
u = sin(t);
h = tf(num, deno);

y1 = lsim(h, u, t);
y2 = step(h, t);
y3 = step(h, 5:0.01:10);

temp = zeros(500, 1);  
y3 = [temp; y3];

y4 = square(t)';

y = y1 + y2 + y3(1:length(t)) + y4;

plot(t, y);
title('Combined System Response');
xlabel('Time (seconds)');
ylabel('Response');
grid on;
