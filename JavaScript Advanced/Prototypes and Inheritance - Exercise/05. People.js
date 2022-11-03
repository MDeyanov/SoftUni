function solve() {
  class Employee {
    constructor(name, age, salary = 0) {
      this.name = name;
      this.age = age;
      this.salary = salary;
    }
    work() {
      console.log(this.tasks[0]);
      this.tasks.push(this.tasks.shift());
    }
    collectSalary() {
      let add = this.dividend !== undefined ? this.dividend : 0;

      console.log(
        `${this.name} received ${this.salary + this.bonus + add} this month.`
      );
    }
  }
  class Junior extends Employee {
    constructor(name, age) {
      super(name, age);
      this.bonus = 0;
      this.tasks = [`${this.name} is working on a simple task.`];
    }
  }
  class Senior extends Employee {
    constructor(name, age) {
      super(name, age);
      this.bonus = 0;
      this.tasks = [
        `${this.name} is working on a complicated task.`,
        `${this.name} is taking time off work.`,
        `${this.name} is supervising junior workers.`,
      ];
    }
  }
  class Manager extends Employee {
    constructor(name, age) {
      super(name, age);
      this.bonus = 0;
      this.dividend = 0;
      this.tasks = [
        `${this.name} scheduled a meeting.`,
        `${this.name} is preparing a quarterly report.`,
      ];
    }
  }
  return {
    Employee,
    Junior,
    Senior,
    Manager,
  };
}