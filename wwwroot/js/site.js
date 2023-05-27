const alertPlaceholder = document.getElementById('liveAlertPlaceholder')
const alertTrigger = document.getElementById('liveAlertBtn')
const alertCloseTrigger = document.getElementById('closeAlert')
const liveAlertPlaceholder_msg = document.getElementById('liveAlertPlaceholder_msg')
if (alertTrigger) {
    alertTrigger.addEventListener('click', () => {
        alertPlaceholder.style.visibility = "Visible"
    })
}
if (alertCloseTrigger) {
    alertCloseTrigger.addEventListener('click', () => {
        alertPlaceholder.style.visibility = "Hidden"
    })
}


