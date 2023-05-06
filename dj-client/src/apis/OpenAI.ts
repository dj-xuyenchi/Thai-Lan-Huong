import axios from "axios";

const KEY = "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";
// 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
// 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
class HeyGPT {
  sayToGPTExeption(exeption: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      axios
        .post(
          `https://api.openai.com/v1/chat/completions`,
          {
            model: "gpt-3.5-turbo",
            messages: [
              {
                role: "user",
                content: "Lỗi " + exeption + " là lỗi gì",
              },
            ],
          },
          {
            headers: {
              Authorization: `Bearer ${KEY}`,
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
  satToGPTQuestion(question: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      axios
        .post(
          `https://api.openai.com/v1/chat/completions`,
          {
            model: "gpt-3.5-turbo",
            messages: [
              {
                role: "user",
                content: question,
              },
            ],
          },
          {
            headers: {
              Authorization: `Bearer ${KEY}`,
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
              Authorization: `Bearer ${KEY}`,
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
