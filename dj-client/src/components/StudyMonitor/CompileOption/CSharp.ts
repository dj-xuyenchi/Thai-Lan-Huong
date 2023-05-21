export const fixCodeCSharp = (code: string) => {
  const time = 1000;
  code = code.replaceAll("\n", "").replaceAll("\r", "").replaceAll("\t", "");
  while (code.includes("do ")) {
    code = code.replace("do ", "do");
  }
  while (code.includes(") ")) {
    code = code.replace(") ", ")");
  }
  code = code.replaceAll(
    "do{",
    `do{timeSpan = stopwatch.Elapsed;if (timeSpan.TotalMilliseconds > ${time}) { Console.WriteLine("ERROR###");break;}`
  );
  for (let i = 0; i < code.length - 5; i++) {
    if (
      code[i] == "w" &&
      code[i + 1] == "h" &&
      code[i + 2] == "i" &&
      code[i + 3] == "l" &&
      code[i + 4] == "e"
    ) {
      for (let j = i + 5; j < code.length - 5; j++) {
        if (code[j] == ")" && code[j + 1] == "{") {
          code =
            code.substring(0, j + 2) +
            `timeSpan = stopwatch.Elapsed;if (timeSpan.TotalMilliseconds > ${time}) { Console.WriteLine("ERROR###");break;}` +
            code.substring(j + 2);
          break;
        }
      }
    }
  }
  for (let e = 0; e < code.length - 3; e++) {
    if (code[e] == "f" && code[e + 1] == "o" && code[e + 2] == "r") {
      for (let r = e + 3; r < code.length - 3; r++) {
        if (code[r] == ")" && code[r + 1] == "{") {
          code =
            code.substring(0, r + 2) +
            `timeSpan = stopwatch.Elapsed;if (timeSpan.TotalMilliseconds > ${time}) { Console.WriteLine("ERROR###");break;}` +
            code.substring(r + 2);
          break;
        }
      }
    }
  }
  for (let f = 0; f < code.length - 6; f++) {
    if (
      code[f] == "f" &&
      code[f + 1] == "o" &&
      code[f + 2] == "r" &&
      code[f + 3] == "e" &&
      code[f + 4] == "a" &&
      code[f + 5] == "c" &&
      code[f + 6] == "h"
    ) {
      for (let g = f + 6; g < code.length - 6; g++) {
        if (code[g] == ")" && code[g + 1] == "{") {
          code =
            code.substring(0, g + 2) +
            `timeSpan = stopwatch.Elapsed;if (timeSpan.TotalMilliseconds > ${time}) { Console.WriteLine("ERROR###");break;}` +
            code.substring(g + 2);
          break;
        }
      }
    }
  }
  return code;
};
