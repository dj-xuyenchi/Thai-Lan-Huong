import axios from "axios";

const KEY = "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";
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
