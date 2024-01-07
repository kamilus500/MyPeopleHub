from flask import Flask, render_template, request, url_for, redirect
from flask_bootstrap import Bootstrap5
from models.RegisterDto import RegisterDto
import services.AccountService as AccountService
app = Flask(__name__)
bootstrap = Bootstrap5(app)

@app.route("/")
def start():
    return redirect(url_for('index'))

@app.route("/index")
def index():
    return render_template("index.html")

@app.route("/login", methods=['POST'])
def login():
    return render_template("login.html")

@app.route("/register", methods=['POST'])
def register():
    if request.method == 'POST':

        registerDto=RegisterDto(
            firstName=request.form.get('FirstName'),
            lastName=request.form.get('LastName'),
            email=request.form.get('Email'),
            login=request.form.get('Login'),
            password=request.form.get('Password')
        )
        AccountService.register(registerDto=registerDto)
        
    return render_template("register.html")

@app.route("/users")
def users_list():
    return render_template("users.html")

@app.route("/friendships")
def friendships_list():
    return render_template("friendships.html")

if __name__ == '__main__':
    app.run(debug=True)