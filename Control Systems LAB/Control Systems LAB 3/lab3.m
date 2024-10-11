

G1 = tf([1],[1 1]);

G2 = tf([1],[1 4]);

G3 = tf([1 3],[1 5]);


GS1 = series(G1,G2);
GSF = series(GS1,G3);


%step(GSF)


GSP1 = parallel(G1,G2);
GFP = parallel(GSP1,G3);

step(GFP)

fd = feedback(GS1,G3);
