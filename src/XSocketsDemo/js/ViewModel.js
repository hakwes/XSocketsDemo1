/// <reference path="../Scripts/knockout-2.1.0.js" />
/// <reference path="../Scripts/jquery-1.7.2.js" />

//KnockoutJS - Our ViewModel
var Person = function (id, name, age, gender, genderstring, colorid, color, fruitid, fruit) {
    this.Id = ko.observable(id);
    this.Name = ko.observable(name);
    this.Age = ko.observable(age);
    this.Gender = ko.observable(gender);
    this.GenderString = ko.observable(genderstring);
    this.FavoriteColorId = ko.observable(colorid);
    this.FavoriteColorName = ko.observable(color);
    this.FavoriteFruitId = ko.observable(fruitid);
    this.FavoriteFruitName = ko.observable(fruit);

    this.FemaleCheck = function () {
        if (this.GenderString() === 'Female') return true;        
        return false;
    };
    this.MaleCheck = function () {        
        if (this.GenderString() === 'Male') return true;        
        return false;
    };
};
var ViewModel = {
    People: ko.observableArray([]),
    Person: ko.observable(new Person()),
    AvailableColors: ko.observableArray([]),
    AvailableFruits: ko.observableArray([]),

    deletePerson: function (p) {
        //Set the viewmodel person to the one we want to delete...
        ViewModel.Person(p);

        //Get confirmation
        $("#personToDelete", "#ModalDeletePerson").text(p.Name());
        $('#ModalDeletePerson').modal('show');
    },
    editPerson: function (p) {
        //Set the viewmodel person to the one we want to edit
        ViewModel.Person(p);

        //Show editable modal
        $('#ModalUpdatePerson').modal('show');
    },

    //Charts Data
    GenderStats: {
        stacked: ko.observable(false),
        seriesList: ko.observableArray([{ legendEntry: false, data: { x: [], y: []}}])
    },

    ColorStats: {
        stacked: ko.observable(false),
        seriesList: ko.observableArray([{ legendEntry: false, data: { x: [], y: []}}])
    },

    FruitStats: {
        stacked: false,
        seriesList: ko.observableArray([{ legendEntry: false, data: { x: [], y: []}}])
    },

    //A hack for calculating chartdata...... but... ;)
    CalculateData: function () {

        //Calc gender and update viewmodel
        ViewModel.GenderStats.seriesList([{ legendEntry: false, data: { x: ['Female', 'Male'], y: [$.grep(ViewModel.People(), function (n, i) { return (n.GenderString() === "Female"); }).length, $.grep(ViewModel.People(), function (n, i) { return (n.GenderString() === "Male"); }).length]}}]);

        var colorData = { x: [], y: [] };
        var fruitData = { x: [], y: [] };

        $.each(ViewModel.People(), function () {
            //calc colors
            if (colorData.x.indexOf(this.FavoriteColorName()) === -1) {
                colorData.x.push(this.FavoriteColorName());
                colorData.y[colorData.x.indexOf(this.FavoriteColorName())] = 1;
            } else {
                colorData.y[colorData.x.indexOf(this.FavoriteColorName())]++;
            }
            //calc ffruits
            if (fruitData.x.indexOf(this.FavoriteFruitName()) === -1) {
                fruitData.x.push(this.FavoriteFruitName());
                fruitData.y[fruitData.x.indexOf(this.FavoriteFruitName())] = 1;
            } else {
                fruitData.y[fruitData.x.indexOf(this.FavoriteFruitName())]++;
            }
        });
        //Update ViewModel
        ViewModel.ColorStats.seriesList([{ legendEntry: false, data: colorData}]);
        ViewModel.FruitStats.seriesList([{ legendEntry: false, data: fruitData}]);
    }
};