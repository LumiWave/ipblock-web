//Tutorials Page... 
function show(id)
{
    if('root-79' == id)
    {        
        let text = $('#select-icon-text').text();
        if('IMG' != text)
        {
            openPopup("Please select a media type", "Please select the NTF media type to be issued.");
            return;
        }
    }

    $('.'+id).css("visibility", "visible");
    return;
}
    
function hide(id)
{
    /* 초기화 */ 
    $('#nft-Title').val('');
    $('#nft-Description').val('');
    
    //전체 선택해제
    $('.img-type-ChoiceField-field').removeClass( 'is-checked' );

    //1번 이미지 선택
    $('#img_1').addClass( 'is-checked' );

    $('.'+id).css("visibility", "hidden");
}

function onmouseOver(id)
{
    $('.'+id).css("border", "1px solid");
}

function onmouseOut(id)
{
    $('.'+id).css("border", "1px dashed");
}

function iconSelect(icon)
{
    //선택 해제
    $('.ms-ChoiceField-wrapper label').removeClass( 'is-checked' );
    
    //선택
    $('.choiceFieldWrapper_'+icon+' label').addClass( 'is-checked' );
}

function checkedNFT()
{
    if(true == $('#choice-label-img').hasClass("is-checked"))
    {
        let HTML = "";
        HTML += '<i role="presentation" aria-hidden="true" class="bowtie-icon bowtie-img artifact-type-icon root-109"></i>';
        document.getElementById('select-icon').innerHTML = HTML;

        let HTML2 = "";
        HTML2 += '<div>IMG</div>';
        document.getElementById('select-icon-text').innerHTML = HTML2;

        $('.root-78').css("visibility", "hidden");
    }
    else
    {
        openPopup("The media type could not be registered", "please wait for the next update.");
    }    
}

function openPopup(title, message)
{
    $('.dialog-background').css("display", "block");
    $('.dialog-background').css("z-index", "1000001");  

    //alert popup            
    $('.title-dialog').text(title);
    $('.message-dialog').text(message);
    
    $('.ui-dialog').css("position", "absolute");
    $('.ui-dialog').css("display", "block");
    $('.ui-dialog').css("z-index", "1000002");   
    $('.ui-dialog').css("top", "25%"); 
    $('.ui-dialog').css("left", "30%"); 
    $('.ui-dialog').css("width", "40%"); 
}

function closePopup()
{
    $('.dialog-background').css("display", "none");
    $('.dialog-background').css("z-index", "-1");  

    $('.ui-dialog').css("position", "absolute");
    $('.ui-dialog').css("display", "none");
    $('.ui-dialog').css("z-index", "-1");   
}

function menuChange()
{
    //선택 해제
    let HTML = "";
    let isChecked = $('.region-navigation').hasClass( 'expanded' );
    if(true == isChecked)
    {
        $('.region-navigation').removeClass( 'expanded' );
                
        HTML += '<div> >> </div>';
        document.getElementById('navigation-arrows').innerHTML = HTML;
    }
    else
    {
        $('.region-navigation').addClass( 'expanded' );
        HTML += '<div> << </div>';
        document.getElementById('navigation-arrows').innerHTML = HTML;
    }    
}


function selectImg(selectImg)
{
    //전체 선택해제
    $('.img-type-ChoiceField-field').removeClass( 'is-checked' );

    //선택한 이미지 표시
    $('#'+selectImg).addClass( 'is-checked' );
}

function movePage(url)
{
    location.href=url;
}