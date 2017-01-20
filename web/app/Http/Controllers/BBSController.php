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

    public function getArticleFromId(int $id)
    {
        $model = new BBSModel();
        $response = $model->getDataFromId($id);
        $response['image'] = $this->getDownLoadArticleImage($response['file_name']);
        return $response;
    }

    public function createArticle(Request $request)
    {
        $model = new BBSModel();
        $body = $request->all();

        if($request->hasFile('image'))
        {
            $image = $request->file('image');
            $name = md5(sha1(uniqid(mt_rand(), true))).'.'.$image->getClientOriginalExtension();
            $body['file_name'] = $name;
            $this->uploadArticleImage($image, $name);
        }

        if(empty($body))
        {
            abort(400, 'リクエストがからです');
        }

         $model->createArticle($body);
         return $model->getLatestData(); //ここはID指定して引っ張ってこれるように修正
    }

    private function uploadArticleImage($image, $name)
    {
        if($image->isValid())
        {
            $image->move(public_path('media'), $name);
            return ;
        }

        abort(444, 'ファイルのアップロードに失敗しました');
    }
}
