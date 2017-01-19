<?php

namespace App;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Http\Request;

class BBSModel extends Model
{
	protected $table = 'bbs_tabale';
    protected $fillable = array('subject','text','email','password','file_name', 'parent_bbs_id', 'is_deleted');
    public function getAllPostingData()
    {
    	$all_data = BBSModel::query()
    		->orderBy('created_at','asc')
    		->get();
    	return $all_data;
    }

    public function getDataFromId(int $id)
    {
    	$datas = BBSModel::query()
    		->where('id', $id)
    		->get();
    	return $datas;
    }

    public function createArticle($request)
    {
        $json = json_decode($request, true);
        $newArticle = BBSModel::create([
                'subject' => $json['subject'],
                'text' => $json['text'],
                'email' => $json['email'],
                'password' => $json['password'],
                'file_name' => $json['file_name'],
                'parent_bbs_id' => 0,
                'is_deleted' => false,
            ]);
        $newArticle->parent_bbs_id = $newArticle->id;
        $newArticle->save();

        return $newArticle;
    }
}
