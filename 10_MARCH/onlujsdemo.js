function test()
{
    console.log('hello');
}

function test2(num1, num2)
{
    return num1+num2;
}

test();
console.log(test2(6,8));

const testme = ()=> console.log("hello ji");
const sum = (n1,n2) => (n1+n2);
console.log(sum(10,54));
testme();

var arr = [10,20,34,24,43,65];
arr.map((ele)=> console.log(ele));

const sq = arr.map(v => v*v);
console.log(sq);

const people = [{ id:1 ,name : "Aman" ,country : "India"},
{ id:2 ,name : "Sam" ,country : "India"},
{ id:3 ,name : "Trump" ,country : "Usa"}];

const names = people.map(x=>x.name);
console.log(names);

var filters = sq.filter(x=>x>1000);
console.log(filters);