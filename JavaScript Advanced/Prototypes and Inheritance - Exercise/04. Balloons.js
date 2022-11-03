function solve() {
  class Balloon {
    constructor(color, hasWeight) {
      this.color = color;
      this.hasWeight = hasWeight;
    }
  }

  class PartyBalloon extends Balloon {
    constructor(color, hasWeight, ribColor, ribLenght) {
      super(color, hasWeight);
      this._ribbon = {
        color: ribColor,
        length: ribLenght,
      };
    }

    get ribbon() {
      return this._ribbon;
    }
  }

  class BirthdayBalloon extends PartyBalloon {
    constructor(color, hasWeight, ribColor, ribLenght, text) {
      super(color, hasWeight, ribColor, ribLenght);
      this._text = text;
    }

    get text() {
      return this._text;
    }
  }

  return { Balloon, PartyBalloon, BirthdayBalloon };
}