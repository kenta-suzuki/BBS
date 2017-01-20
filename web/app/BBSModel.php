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

    public function getLatestData()
    {
        $latestData = BBSModel::query()
            ->orderBy('created_at','desc')
            ->first();
        return $latestData;
    }

    public function createArticle($request)
    {
        $newArticle = BBSModel::create([
                'subject' => $request['subject'],
                'text' => $request['text'],
                'email' => $request['email'],
                'password' => $request['password'],
                'file_name' => $request['file_name'],
                'parent_bbs_id' => 0,
                'is_deleted' => false,
            ]);
        $newArticle->parent_bbs_id = $newArticle->id;
        $newArticle->id = $newArticle->id;
        $newArticle->save();
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
