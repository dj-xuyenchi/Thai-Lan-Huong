import axios from "axios";

class HeyGPT {
  sayToGPTExeption(
    code: string,
    expectOutput: string,
    exeption: string
  ): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      axios
        .post(
          `https://api.openai.com/v1/chat/completions`,
          {
            model: "gpt-3.5-turbo",
            messages: [
              {
                role: "user",
                content:
                  "Đây là đoạn code của tôi bằng C#. using System; namespace HelloWorld { class Program { static void Main(string[] args) { " +
                  code +
                  "  } } }tôi mong muốn nhận được kết quả là " +
                  expectOutput +
                  " nhưng tôi chạy bị lỗi " +
                  exeption +
                  " lỗi đó là lỗi gì vậy. giải thích lỗi không trả lời cách sửa.",
              },
            ],
          },
          {
            headers: {
              Authorization: `Bearer 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`,
            },
          }
        )
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
  sayToGPTWrong(
    code: string,
    expectOutput: string,
    realOuput: string
  ): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      axios
        .post(
          `https://api.openai.com/v1/chat/completions`,
          {
            model: "gpt-3.5-turbo",
            messages: [
              {
                role: "user",
                content:
                  "Đây là đoạn code của tôi bằng C# `" +
                  code +
                  "` tôi mong muốn nhận được kết quả là `" +
                  expectOutput +
                  "` nhưng tôi lại nhân được `" +
                  realOuput +
                  "` giải thích giúp tôi nhưng không hướng dẫn cách sửa để tôi tự nghĩ.",
              },
            ],
          },
          {
            headers: {
              Authorization: `Bearer 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`,
            },
          }
        )
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
}
export default new HeyGPT();