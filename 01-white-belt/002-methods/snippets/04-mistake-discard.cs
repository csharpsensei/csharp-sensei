// MISTAKE 1 — calling a method and throwing away the answer

CalculateTotal(9, 9);               // runs fine... result vanishes

int total = CalculateTotal(9, 9);   // store it — now you can use it
