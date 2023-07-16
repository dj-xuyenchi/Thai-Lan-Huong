export const fixCodeJS = (code: string, callTest: string) => {
  const time = 1000;
  code =
    "const logToVariable = function (message) { logOutput += message; };  console.log = logToVariable; const startTime = new Date();" +
    code;
  code = code.replaceAll("\n", "").replaceAll("\r", "").replaceAll("\t", "");
  while (code.includes("do ")) {
    code = code.replace("do ", "do");
  }
  while (code.includes(") ")) {
    code = code.replace(") ", ")");
  }
  code = code.replaceAll(
    "do{",
    `do{const endTime = new Date();if (endTime - startTime>${time}) { console.log("ERROR###");break;}`
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
            `const endTime = new Date();if (endTime - startTime>${time}) { console.log("ERROR###");break;}` +
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
            `const endTime = new Date();if (endTime - startTime>${time}) { console.log("ERROR###");break;}` +
            code.substring(r + 2);
          break;
        }
      }
    }
  }
  code =
    code +
    callTest +
    "const endTime1 = new Date();const executionTime = endTime1 - startTime;console.log('RESULT###'+ executionTime);";

  return code;
};
export const runCode = (code: string, variable: string) => {
  code = code.replace("variable", variable);
  let logOutput = "";
  logOutput = "";
  try {
    eval(code); // Chạy mã JavaScript
    return logOutput;
  } catch (error: any) {
    return error.message; // Thông báo lỗi
  }
};
