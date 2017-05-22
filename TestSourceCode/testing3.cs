class stmtTests
{
    public static void mayBeEmpryBlock()
    {
        {
            {;;;;;;
                {
                    ;;;;;
                };;{};;;;;;
            }
        }{}{}{}{}{}{}{};;;;{}{}{}{};;{}
    }

    private static void selectionStmt()
    {
        bool hola = false;
        string mama = "adios";
        if(true){
            if(hola);
            int value;
            if((hola?(((5 * 9 / 3) - 7 + (2 * 7 + 4) / ( (128 >> 5 * 5) - (1 << 7 * 46) / 3 )) + 15):(((mama += " como" + (9*5))=="s")?3:6)) is int)
            {
                value = 7;
            }else{
                value = 9;
                if (look_ahead.Count > 0)
                {
                    token = look_ahead[0];
                    removeLookAhead(0);
                }
                else
                {
                    token = lexer.GetNextToken();
                }
            }
            switch(value)
            {
                case 9:
                    {
                        var ass = new stmtTests[,,,]{};
                    }
                    break;
                case 8:
                default:
                    break;
            }
        }else{

        }
    }

    public static void iterationStmt()
    {
        for(;;);
        for(;;)
        {
            while(false)
            {
                var ultimatum = "adios compita";
            }
            do{

            }while(0);

            //comidas.hola[7] = nada;

            foreach(var type in types)
                if(type.Contains(token.type))
                {

                }
        }
    }

    public static void statementsExpressions()
    {
        namespace1.namespace2.namespace3.MuClass nameVar = new namespace1.namespace2.namespace3.MuClass();
        namespace1.namespace2.namespace3.MuClass[] nameVar = new namespace1.namespace2.namespace3.MuClass[]{};
        namespace1.namespace2.namespace3.MuClass[][] nameVar = new namespace1.namespace2.namespace3.MuClass[][]{};
        namespace1.namespace2.namespace3.MuClass[,,] nameVar = new namespace1.namespace2.namespace3.MuClass[,,]{};

        Persona[] varName2 = createPrenson("Carlos");
        varName2.edad = birthy_ear - current_year;
        varName2.sueldo *= 1.5f;
        varName2.carros.add(new Ferrarry());

        Lol que = new Lol[6][];
        Lol que = new Lol[][]{};
        Lol que = new Lol[,,,]{};

        hola = "adios";

        hola[2] = "adios";
        Console.WriteLine("Hello!");

        namespace1.namespace2.namespace3.MuClass[0] = "Ing.";
        namespace1.namespace2.MuClass[1] = "no";
        namespace1.MuClass[2] = "nos";
        namespace1.namespace2.MuClass[3] = "viole";
        namespace1.namespace2.namespace3.MuClass[4] = "plox";
        namespace1.namespace2.namespace3.MuClass[5] = "plox X2";

        int THREE = 3,
        FOUR = 4;

        float[] rangos = new float[5];
        rangos[0] = 5.25f;
        rangos[1] = 5.25F;
        rangos[2] = (float)9;
        rangos[3] = 5.25f;
        rangos[FOUR] = (float)200;

        this.myField = new Fielded(otroParam);
        this.myField2[THREE] = new Fielded(otroParam);

        this.myField3.id1.id2[THREE] = new Fielded(otroParam);
        this.myField3.id1 = new ID1(otroParam,otroParam2,otroParam3);

        string[] nombres1 = new namespace1.MyBool[getSize()];
        string[] nombres2 = new namespace1.MyBool[this.getSize()];
        string[] nombres2 = new namespace1.MyBool[(Numbers.Count>3)?8:3];

        nombres1[getSize()-1] = "Imposible";
        nombres1[this.getSize()-1] = "Thing";
        nombres1[(Numbers.Count>3)?8:3] = "Last";

        namespace1.MyBool[size *= 3] = value1;
        namespace1.MyBool[size += 3] = value2;
        namespace1.MyBool[((size -= 3)>0)?size:0] = value3;

        int size = 5;
        float[] val = new float[8];
        val[size *= 3] = (float)5.5F;
    }

    private static TokenType [] jumpsStmt()
    {
        TokenType[] nuevo = {TokenType.OP_TERNARY, TokenType.PUNT_COLON,
            TokenType.OP_NULL_COALESCING, TokenType.OP_OR,
            TokenType.OP_AND, TokenType.OP_BITWISE_OR,
            TokenType.OP_XOR, TokenType.OP_BITWISE_AND,
            TokenType.PUNT_PAREN_OPEN, TokenType.RW_NEW,
            TokenType.ID, TokenType.RW_THIS};
        
        foreach(var type in types)
        {
            if(type.Contains(token.type))
            {
                break;
            }else{
                continue;
            }
        }

        return nuevo.Concat(equalityOperatorOptions).Concat(relationalOperatorOptions).
            Concat(Is_AsOperatorOptions).Concat(shiftOperatorOptions).Concat(additiveOperatorOptions).
            Concat(multiplicativeOperatorOptions).Concat(assignmentOperatorOptions).Concat(unaryOperatorOptions)
            .Concat(literalOptions).ToArray();
    }
}