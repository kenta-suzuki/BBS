<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Http\Response;
use App\BBSModel;

class BBSController extends Controller
{
    public function getAllArticle()
    {
        $model = new BBSModel();
    	return $model->getAllPostingData();
    }

    public function createArticle(Request $request)
    {
        $model = new BBSModel();

        if(empty($request->all()))
        {
            abort(400, 'リクエストがからです');
        }

         $response = $model->createArticle($request);
         return $model->getDataFromId($response->id); //ここはID指定して引っ張ってこれるように修正
    }
}
