    var data = [
       {Url:"\\Images\\FileWebSitePhotos\\Flowers\\flowerChai.jpg", ProductName: "chai", Price: "94 nis"},
       {Url:"\\Images\\FileWebSitePhotos\\Flowers\\flowerVelvet.jpg", ProductName: "velvet", Price: "104 nis"},
       {Url:"\\Images\\FileWebSitePhotos\\Flowers\\flowerAnise.jpg", ProductName: "Anise", Price: "120 nis"}
    ];

    var Product = React.createClass({
        render: function() {                        
            return (
                <div className="product">
                    <div className="image">
                        <img src={this.props.currentProduct.Url} className="imagepro" alt="flower" />
                    </div>
                    <div className="nameProduct">
                        <div className="left">
                            <b>{this.props.currentProduct.ProductName}</b>
                        </div>
                        <div className="right">
                            <b>{this.props.currentProduct.Price}</b>
                        </div>
                    </div>
                    <div className="btnmoredetails">
                        <a href="#" className="btn btn-primary btnmoredetails" role="button">more details</a>
                    </div>
               </div>
            );
        }
    });

    var ProductList = React.createClass({
        render: function() {                        
            return (
                   <div>
                         <div className="productLeft">
                            <Product currentProduct={this.props.data[0]} />
                         </div>
                         <div className="productMiddle">
                            <Product currentProduct={this.props.data[1]} />
                         </div>
                         <div className="productRight">
                            <Product currentProduct={this.props.data[2]} />
                         </div>
                    </div>
                );
        }
    });

    ReactDOM.render(
        <ProductList data={data} />,
        document.getElementById('products')
    ); 