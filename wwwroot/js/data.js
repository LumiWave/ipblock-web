function setNFT()
{
    const title = $('#nft-Title').val();
    const description = $('#nft-Description').val();
    let thumbnail_url = "";

    $('.img-type-ChoiceField-field').each(function()
    {   
        if(true == $(this).hasClass('is-checked'))
        {
            var selectID = $(this).attr('id'); 
            thumbnail_url = "https://onbuff.com/pjtCom/images/hard_"+selectID+".png";
        }
    });

    $.ajax({   
        type: 'post',
        dataType: 'json',
        cache: false,
        url: '/Tutorials/setNFT',
        data: { title: title, description: description, thumbnail_url: thumbnail_url },
        success: function (response, textStatus, jqXHR) {
            
            const result_data = JSON.parse(response);            
            const data = JSON.parse(result_data.Value);  
            const code = data.code;
            const message = data.message;

            if(0 < code)
            {
                openPopup(message, "Error code :"+code);  
            }
            else
            {
                let HTML = '<button type="button" onclick="movePage(\'../Tutorials/List\');" class="cta ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only">';
                HTML += '<span class="ui-button-text">OK</span>'
                HTML += '</button>'
                document.getElementById('popup-button-ok').innerHTML = HTML;

                const text = "Registration is complete. NFT issuance is in progress, and you can check it on the LIST."                
                openPopup(message, text);  
            }            
        },
        error: function(jqXHR, textStatus, errorThrown) {
            console.log('Error : ' + errorThrown);
        }
      });
}

function getNFT(page_id)
{
    $.ajax({   
      type: 'post',
      dataType: 'json',
      cache: false,
      url: '/Tutorials/getNFTList',
      data: { page_offset: (page_id-1), page_size: page_size},
      success: function (response, textStatus, jqXHR) {
                 
        const result_data = JSON.parse(response);            
        const data = JSON.parse(result_data.Value);        
        const code = data.code;
        const message = data.message;
        const page_info = data.value.page_info;
        const items = data.value.items;                
        let HTML = ""; 

        $.each(items, function(key, value)
        {                        
            HTML += "<tr>";            
            HTML += "<td>"+value.item_id+"</td>";
            HTML += "<td>"+value.title+"</td>";
            HTML += "<td><img src='"+value.thumbnail_url+"' alt='' width='150' height='155'></td>";
            HTML += "<td>"+value.description+"</td>";

            if(0 < value.token_id)
            {
              HTML += "<td>complete</td>";
            }
            else
            {
              HTML += "<td>waiting</td>";
            }

            HTML += "<td>"+value.owner+"</td>";            
            HTML += "</tr>";                        
        });
      
        document.getElementById('items').innerHTML = HTML;
                
        //total_size
        totalCount = page_info.total_size;
        
        //paging
        let pageCnt = Number(totalCount) / Number(page_size);
        pageCnt = Math.ceil(pageCnt);
        
        if (1 < Number(pageCnt))
        {
            makePaging(pageCnt, page_id);
        }
        else 
        {
            $("#paging").empty();
        }        

      },
      error: function(jqXHR, textStatus, errorThrown) {
        console.log('Error : ' + errorThrown);
      }
    });
}

//페이지 이동
function pageMove(page_id)
{
    if(0 >= page_id) page_id=1;    

    getNFT(page_id);
}

//페이징 처리
function makePaging(pageCnt, nowPage)
{
    let content = '';
    const chknumber = Number(nowPage % 10);
    const number = Math.floor(Number(nowPage / 10));
    const unitNumber = (number * 10);

    content += "<div class='pagination'>";
    content += "<a class='prev arrow_common' onclick='pageMove(" + (nowPage-1) + ")'>prev</a>";

    if(nowPage == unitNumber)
    {
        for (i = 1; i <= page_length; i++)
        {                
            if (i == (chknumber+10))
            {                            
                content += "<a class='active'>" + nowPage + "</a>";
            }
            else
            {            
                const page = Number((unitNumber+i)-10);
                if(page > pageCnt) continue;

                content += "<a href='javascript:pageMove(" + page + ")'>" + page + "</a>";
            }                    
        }
    }
    else
    {
        for (i = 1; i <= page_length; i++)
        {                
            if (i == chknumber)
            {            
                content += "<a href='#' class='active'>" + nowPage + "</a>";
            }
            else
            {            
                const page = Number(unitNumber+i);
                if(page > pageCnt) continue;

                content += "<a href='#' onclick='pageMove(" + page + ")'>" + page + "</a>";
            }                    
        }
    }

    if(pageCnt != nowPage)
    {
        content += "<a class='next arrow_common' onclick='pageMove(" + (nowPage+1) + ")'>next</a>";
    }
    else
    {
        content += "<a class='next arrow_common' onclick='pageMove(" + nowPage + ")'>next</a>";
    }
    content += "</div>";

    $("#paging").empty();
    $('#paging').append(content);
}
