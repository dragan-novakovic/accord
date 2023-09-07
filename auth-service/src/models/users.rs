use bson::oid::ObjectId;

#[derive(Clone, Serialize, Deserialize)]
pub struct PublicUser {
    pub id: Option<String>,
    pub username: Option<String>,
    pub token: Option<String>,
}

#[derive(Serialize, Deserialize, Debug, Clone)]
pub struct User {
    #[serde(rename = "_id")]
    pub id: Option<ObjectId>,
    pub username: Option<String>,
    pub password: Option<String>,
    pub token: Option<String>,
}

impl From<User> for PublicUser {
    fn from(sub: User) -> Self {
        PublicUser {
            id: sub.id.map(|oid| oid.to_hex()),
            username: sub.username,
            token: sub.token,
        }
    }
}

impl User {
    pub fn remove_password(mut self) -> Self {
        self.password = None;
        self
    }

    pub fn generate_token(mut self, token: String) -> Self {
        self.token = Some(token);
        self
    }
}

#[derive(Serialize, Deserialize, Debug, Clone)]
pub struct InsertableUser {
    pub username: Option<String>,
    pub password: Option<String>,
}

impl InsertableUser {
    // pub fn from_user(user: User) -> InsertableUser {
    //     InsertableUser {
    //         username: user.username,
    //         password: user.password,
    //     }
    // }
}
