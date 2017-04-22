function validate() {
    var validator = new IValidation("forms", true)
    validator.initValidation();
    return iFormIsValid(validator);
}