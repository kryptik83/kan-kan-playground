console.log("hello world");

function add(a, b) {
    var c= a+b;
    return c;
}

String.prototype.toCamelCase = function() {
    return this.replace(/^([A-Z])|\s(\w)/g, function(match, p1, p2, offset) {
        if (p2) return p2.toCamelCase();
        return p1.toLowerCase();        
    });
};

console.log(add(1,2));

var name = "vijit khanna";
console.log(name.toCamelCase());

var arr1 = [1,2,3];
var arr2 = [1,2,3];
var looseequality = arr1== arr2;
var strictequality = arr1 === arr2;
