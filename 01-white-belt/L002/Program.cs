// C# Sensei — Lesson 002: What is a Method?
// Belt: ⬜ White
// Video: https://youtube.com/@CSharpSensei  (link the video here once live)

// ---------------------------------------------------------------
// A method is a named, reusable block of code.
// It takes input (parameters), does work, and can hand back a result.
// ---------------------------------------------------------------

// Calling the method — the logic lives in ONE place, called from many.
int total = CalculateTotal(5, 3);
Console.WriteLine($"Total: {total}");

int bulkOrder = CalculateTotal(12, 40);
Console.WriteLine($"Bulk order: {bulkOrder}");

// Mistake #1 from the video: calling a method and throwing away the answer.
// This compiles with no error and no warning — the result just vanishes.
CalculateTotal(9, 9);

// ---------------------------------------------------------------
// The method itself.
// Anatomy:  return type → name → parameter list
//           int   CalculateTotal   (int price, int quantity)
//
// Note: whole numbers (int) keep this lesson simple.
// Real money code uses `decimal` — that's a later lesson.
// ---------------------------------------------------------------
int CalculateTotal(int price, int quantity)
{
    return price * quantity;
}
