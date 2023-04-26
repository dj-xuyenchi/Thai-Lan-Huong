import axios from "axios";

class HeyGPT {
  sayToGPT(content: string): Promise<any> {
    return new Promise<any>((resolve: any, reject: any) => {
      axios
        .post(
          `https://api.openai.com/v1/chat/completions`,
          {
            model: "gpt-3.5-turbo",
            messages: [{ role: "user", content: content }],
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
