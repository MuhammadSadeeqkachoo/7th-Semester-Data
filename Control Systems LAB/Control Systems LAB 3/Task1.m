
G1 = tf([1],[1 1]);

G2 = tf([1],[1 4]);

G3 = tf([1 3],[1 5]);

G12 = series(G1,G2);


G12P3 = parallel(G12,G3);

A = series(G12,G12P3);

G1P2 = parallel(G1,G2);

B = series(G1P2,G3);

final = feedback(A,B)

step(final);