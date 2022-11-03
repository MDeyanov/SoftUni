describe("isOddOrEven func", () => {
  it("happy", () => {
    expect(isOddOrEven("1")).to.equal("odd", "works");
  });
  it("happy", () => {
    expect(isOddOrEven("11")).to.equal("even", "works");
  });
  it("happy", () => {
    expect(isOddOrEven([])).to.equal(undefined, "works");
  });
  it("happy", () => {
    expect(isOddOrEven(1)).to.equal(undefined, "works");
  });
  it("happy", () => {
    expect(isOddOrEven(11)).to.equal(undefined, "works");
  });
});