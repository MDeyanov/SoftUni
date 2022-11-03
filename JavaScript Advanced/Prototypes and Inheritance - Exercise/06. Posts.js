function solve() {
  class Post {
    constructor(/*...input */ t, c) {
      //   let index = 0;
      this.title = t; // input[index++];
      this.content = c; // input[index++];
    }
    toString() {
      return [`Post: ${this.title}`, `Content: ${this.content}`].join("\n");
    }
  }
  class SocialMediaPost extends Post {
    constructor(/*...input */ t, c, l, d) {
      //   let index = 0;
      super(/*input[index++], input[index++]*/ t, c);
      this.likes = l; // input[index++];
      this.dislikes = d; // input[index++];
      this.comments = [];
    }
    addComment(str) {
      this.comments.push(str);
    }

    toString() {
      let temp = [super.toString()];
      temp.push(`Rating: ${this.likes - this.dislikes}`);
      if (this.comments.length > 0) {
        // let strr = "Comments:";
        // this.comments.forEach((c) => (strr += `\n * ${c}`));
        // temp.push(strr);
        temp.push(
          ...this.comments.reduce((a, e) => (a.push(` * ${e}`), a), [
            `Comments:`,
          ])
        );
      }
      return temp.join("\n");
    }
  }
  class BlogPost extends Post {
    constructor(/*...input */ t, c, v) {
      //   let index = 0;
      super(/*input[index++], input[index++]*/ t, c);
      this.views = v; // input[index++];
    }
    view() {
      this.views++;
      return this;
    }
    toString() {
      let temp = [super.toString()];
      temp.push(`Views: ${this.views}`);
      return temp.join("\n");
    }
  }
  return { Post, SocialMediaPost, BlogPost };
}
