const express = require('express');
const app = express();

let users = [];
let user

app.use(express.json());

app.get('/', (req, res)=> {
    console.log('hello world!');
});

app.get('/scores/:id', (req, res)=> {
    console.log('id :' + req.params.id);
    let user = users.find(x=>x.id == req.params.id);
    
    if(user === undefined)
    {
     res. send({
        cmd : 1103,
        message : '잘못된 id 입니다. '
     });
    }
     else
     {
       res.send({
        cmd : 1102,
        message : '',
        result : user,
       });
     }
});

app.get('/scores/top3', (req, res)=> {
    let result = users.sort(function (a,b) {
        return b.score - a.score;
    });

    result= result.slice(0,3);

    res.send({
        cmd : 1101,
        message : '',
        result
       });
    });

app.post('/scores', (req,res)=>{
    const {id ,score} = req.body;

    console.log(req.body);

    let result = {
        cmd : -1,
        messasge : ''
    };

    let user = users.find(x=>x.id == id);

    if(user === undefined)
    {
        users.push({id, score});
        result.cmd = 1001;
        result.messasge = '점수가 신규 등록 되었습니다.'
    }
    else
    {
      console.log(scorem, id,  user.score);

      if(score > user.score)
      {
        user.score= score;
        result.cmd = 1002;
        result.messasge = '점수가 갱신 되었습니다 '
      }
      else
      {
        result.cmd = 1003;
      }
    }
    console.log(users);
    res.send(result);
})

app.listen(3030, ()=> {
    console.log('server is running at 3030 port');
})

app.post('/scores', (req,res)=>{
  const {id ,score} = req.body;

  console.log(req.body);

  let result = {
      cmd : -1,
      messasge : ''
  };

  let user = users.find(x=>x.id == id);

  if(user === undefined)
  {
      users.push({id, score});
      result.cmd = 1001;
      result.messasge = '점수가 신규 등록 되었습니다.'
  }
  else
  {
    console.log(scorem, id,  user.score);

    if(score > user.score)
    {
      user.score= score;
      result.cmd = 1002;
      result.messasge = '점수가 갱신 되었습니다 '
    }
    else
    {
      result.cmd = 1003;
    }
  }
  console.log(users);
  res.send(result);
})


app.post('/register', (req,res)=>{

  console.log(req.body.userid.id);
  let id = req.body.userid.id;
  let password = req.body.userid. password;
  let result = {
      cmd : -1,
      messasge : ''
  };

  let user = users.find(x=>x.id == id);

  if(user === undefined)
  {
      users.push({id, score});
      result.cmd = 1101;
      result.messasge = '신규 아이디가 등록 되었습니다.'
  }
  else
  {
    result.cmd = 1102;
      result.messasge = ' 이미 존재하는 아이디 입니다.'

  }
   res.send(result);
});