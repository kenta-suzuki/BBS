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

    public function getPostingData(int $id)
    {
        $model = new BBSModel();
        return $model->getDataFromId($id);
    }

    public function createArticle($request)
    {
        $model = new BBSModel();
        return $model->createArticle($request);
    }

    public function updateArticle(Request $request)
    {

    }
}
