using AiConverter.Cli.DTOs;

namespace AiConverter.Cli.Misc;

public static class Prompts {
   public static string GetGnjConclusionPrompt(GnjConclusionInputDto input) => $@"
Return a JSON only, with this exact structure:

{{
    ""id"": ""{input.Id}"",
    ""nt"": """",
    ""kw"": []
}}

General Instructions:

- The input text may be **old or archaic Persian**.
- You MUST:
  - Correct **punctuation**.
  - Ensure **right-to-left (RTL)** Persian formatting.
  - Rewrite old or unclear text into **modern, official, and clear Persian**,
    understandable for the **general audience today**.

Specific Instructions:

1. Rewrite the input title ('{input.Title}') into a **new title** ('nt'):
   - Text must be **Persian (Farsi)**.
   - Use **modern, official, and readable language**.
   - Avoid archaic expressions unless absolutely necessary.
   - Ensure correct **Persian punctuation** (، ؛ . ؟).
   - Keep the meaning faithful, but improve clarity.
   - 'nt' must NOT be empty.

2. Extract up to 5 keywords into the 'kw' array:
   - Keywords must be in **Persian**.
   - Use information from:
     - The old title
     - The rewritten title
     - Existing keywords (Keyword1-Keyword5)
   - Each keyword should be a **more specific subcategory** of the previous one.
   - Keywords must be **plain text words** (no ""#"" or symbols),
     but follow a consistent system for future topic-based classification.
   - Avoid empty strings.
   - Maximum of 5 keywords.

3. Final Output:
   - The output JSON must provide a **systematic structure** of keywords,
     so that **at the end it is possible to categorize the topics** according to these keywords (هشتگ‌ها).

4. Output Rules:
   - Output **ONLY valid JSON**.
   - No explanations, notes, markdown, or backticks.
   - No comments inside JSON.
   - JSON must be fully parsable.

Input Keywords:
- {input.Keyword1 ?? "(none)"}
- {input.Keyword2 ?? "(none)"}
- {input.Keyword3 ?? "(none)"}
- {input.Keyword4 ?? "(none)"}
- {input.Keyword5 ?? "(none)"}
";
}
