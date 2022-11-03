class Story {

    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes() {
        if (this._likes.length === 0) {
            return `${this.title} has 0 likes`;
        } else if (this._likes.length === 1) {
            return `${this._likes[0]} likes this story!`;
        } else {
            return `${this._likes[0]} and ${this._likes.length - 1} others like this story!`;
        }
    }

    like(username) {
        if (this._likes.includes(username)) {
            throw new Error(`You can't like the same story twice!`);
        } else if (username === this.creator) {
            throw new Error(`You can't like your own story!`);
        } else {
            this._likes.push(username);
            return `${username} liked ${this.title}!`;
        }
    }

    dislike(username) {
        if (!this._likes.includes(username)) {
            throw new Error(`You can't dislike this story!`);
        } else {
            let indexToRemove = this._likes.indexOf(username);
            this._likes.splice(indexToRemove, 1);
            return `${username} disliked ${this.title}`
        }
    }

    comment(username, content, id) {
        let commentWithId = this._comments.find(co => co.commentId === id);
        if (commentWithId === undefined || id === undefined) {
            let newComment = {
                commentId: this._comments.length + 1,
                username: username,
                content: content,
                "Replies": [],
            }
            this._comments.push(newComment);
            return `${username} commented on ${this.title}`;

        }

        let replyId = id + '.' + (commentWithId.Replies.length + 1);
        commentWithId.Replies.push({commentId: replyId, username: username, content: content});
        return `You replied successfully`;

    }

    toString(sortingType) {
        let sortedArr;
        let data;
        sortedArr = this._sortArrayBySortingType(this._comments, sortingType);
        data = `Title: ${this.title}\nCreator: ${this.creator}\nLikes: ${this._likes.length}\n`;
        data += `Comments:\n`;

        if (sortedArr.length === 0) {
        } else {
            for (let comment of sortedArr) {
                data += `-- ${comment.commentId}. ${comment.username}: ${comment.content}\n`;
                if (comment.Replies.length > 0) {
                    let commentIndex = this._comments.indexOf(comment);
                    let sortedReplies = this._sortArrayBySortingType(comment.Replies, sortingType, commentIndex);
                    for (let reply of sortedReplies){
                        data += `--- ${reply.commentId}. ${reply.username}: ${reply.content}\n`;
                    }
                }
            }
        }
        return data.trim();
    }

    _sortArrayBySortingType(arrayToBeSorted, sortingType, commentIndex) {
        let sortedArr;
        if (commentIndex === undefined) {
            arrayToBeSorted = this._comments;
        } else {
            arrayToBeSorted = this._comments[commentIndex].Replies;
        }

        if (sortingType === "desc") {
            sortedArr = arrayToBeSorted.sort((a, b) => b.commentId - a.commentId);
        } else if (sortingType === "asc") {
            sortedArr = arrayToBeSorted.sort((a, b) => a.commentId - b.commentId);
        } else if (sortingType === "username") {
            sortedArr = arrayToBeSorted.sort((a, b) => a.username.localeCompare(b.username))
        }
        return sortedArr;
    }
}