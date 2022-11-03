function sort(array, argument){
    if(argument == 'asc'){
        array.sort((a, b) => a - b);
    }
    else{
        array.sort((a, b) => b - a);
    }
    return array;
}