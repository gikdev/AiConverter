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

Instructions:

1. Rewrite the input title ('{input.Title}') into a **new title** ('nt'):
   - Make it simpler, easy to read.
   - Use casual language that would make sense to professors and engineers.
   - Avoid overly formal or flowery text.
   - 'nt' cannot be empty.

2. Extract up to 5 keywords (as much as it makes sense) into the 'kw' array:
   - Use information from the old title, the new title, and any existing keywords (Keyword1-Keyword5 from the input).
   - Each keyword must be a **subcategory** of the previous keyword.
   - Avoid empty strings.
   - Maximum of 5 keywords.

3. Output rules:
   - Only JSON; do **not** include explanations, notes, or extra text, or even backticks for code blocks (`).
   - Ensure the JSON is **valid and parsable**.
   - Do not include comments inside the JSON.

Input Keywords:
- {input.Keyword1 ?? "(none)"}
- {input.Keyword2 ?? "(none)"}
- {input.Keyword3 ?? "(none)"}
- {input.Keyword4 ?? "(none)"}
- {input.Keyword5 ?? "(none)"}
";
}
