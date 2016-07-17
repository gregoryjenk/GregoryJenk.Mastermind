function sayHello() {
    const compiler = (document.getElementById("compiler") as HTMLInputElement).value;
    const framework = (document.getElementById("framework") as HTMLInputElement).value;

    return `Hello from ${compiler} and ${framework}!`;
}

class Greeter {
    constructor(public greeting: string) {

    }

    greet():string {
        return this.greeting;
    }
};