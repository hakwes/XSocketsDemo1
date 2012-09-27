//Commands that mirror the once in the plugin (for less strings)
var Commands = {
    Person: {
        Binding: {
            GetAll: 'Person.Trigger.GetAll',
            Created: 'Person.Trigger.Created',
            Updated: 'Person.Trigger.Updated',
            Deleted: 'Person.Trigger.Deleted'
        },
        Trigger: {
            GetAll: 'Person.Bind.GetAll',
            Create: 'Person.Bind.Create',
            Update: 'Person.Bind.Update',
            Delete: 'Person.Bind.Delete'
        }
    },
    Color: {
        Binding: {
            GetAll: 'Color.Trigger.GetAll'
        }
    },
    Fruit: {
        Binding: {
            GetAll: 'Fruit.Trigger.GetAll'
        }
    },
    Global: {
        Trigger: {
            Init: 'Global.Bind.Init'
        }
    }
};