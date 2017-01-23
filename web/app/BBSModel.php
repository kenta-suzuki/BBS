<?php

namespace App;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Http\Request;
use Illuminate\Http\Response;

class BBSModel extends Model
{
	protected $table = 'bbs_tabale';
    protected $fillable = array('subject','text','email','password','file_name', 'parent_bbs_id', 'is_deleted');
    public function getAllPostingData()
    {
    	$all_data = BBSModel::query()
    		->orderBy('created_at','asc')
    		->get();

        foreach ($all_data as $data)
        {
            $data['image'] = $this->getDownLoadArticleImage($data->file_name);
        }

        return $all_data;
    }

    public function getDataFromId(int $id)
    {
    	$data = BBSModel::query()
    		->where('id', $id)
    		->first();
        $data['image'] = $this->getDownLoadArticleImage($data->file_name);
    	return $data;
    }

    public function createArticle($request)
    {
        $body = $request->all();

        if($request->hasFile('image'))
        {
            $image = $request->file('image');
            $name = md5(sha1(uniqid(mt_rand(), true))).'.'.$image->getClientOriginalExtension();
            $body['file_name'] = $name;
            $this->uploadArticleImage($image, $name);
        }

        $newArticle = BBSModel::create([
                'subject' => $body['subject'],
                'text' => $body['text'],
                'email' => $body['email'],
                'password' => $body['password'],
                'file_name' => $body['file_name'],
                'parent_bbs_id' => 0,
                'is_deleted' => false,
            ]);

        if($request->has('parent_bbs_id'))
        {
            $newArticle->parent_bbs_id = $body['parent_bbs_id'];
        }
        else
        {
            $newArticle->parent_bbs_id = $newArticle->id;
        }

        $newArticle->id = $newArticle->id;
        $newArticle->save();
        return $newArticle;
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

    public function getDownLoadArticleImage($name)
    {
        $filename = public_path('media'). '/'.$name;
        $handle = fopen($filename, "rb");
        $contents = fread($handle, filesize($filename));
        fclose($handle);

        return base64_encode($contents);
    }
}
