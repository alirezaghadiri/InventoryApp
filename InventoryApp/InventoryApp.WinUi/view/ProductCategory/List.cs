﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryApp.Framwork;
using InventoryApp.Entities;
using InventoryApp.RepositortAbstracts;
using InventoryApp.Repositories;

namespace InventoryApp.WinUi.view.Category
{
    public class List : ViewBase
    {
        IProductCategory CatRep;
        TreeControl<Entities.ProductCategory> treeControl;
        public List(IProductCategory CatRep)
        {
            this.CatRep = CatRep;
        }
        protected override void OnLoad(EventArgs e)
        {
            AddAction("جدید", btn =>
             {
                 var view = viewEngine.ViewInForm<view.ProductCategory.Editor>(editor =>
                 {
                     if (treeControl.SelectedObject != null)
                         if (MessageBox.Show("ایا می خواهید به ریشه اضاف کنید", "پیام سیستم", MessageBoxButtons.YesNo) == DialogResult.No)
                             editor.ParentCategory = treeControl.SelectedObject;
                 }, true);
                 if (view.DialogResult == DialogResult.OK)
                 {
                     if (view.Entity.SubProductCategoryID != 0)
                     {
                         var CapacityParent = CatRep.Find(view.Entity.SubProductCategoryID).Capacity;
                         List<Entities.ProductCategory> data = CatRep.GetByParent(view.Entity.SubProductCategoryID).ToList();
                         decimal count = 0;
                         foreach (var item in data)
                         {
                             count += item.Capacity;
                         }
                         var newcapacity = count + view.Entity.Capacity;
                         if (newcapacity <= CapacityParent)
                         {
                             if (CatRep.Add(view.Entity))
                             {
                                 MessageBox.Show("دسته بندی  با موفقیت ثبت شد", "پیام سیستم");
                                 treeControl.InitRoots();
                             }
                             else
                             {
                                 MessageBox.Show("مشکل در ثبت دسته بندی به وجود آمد", "پیام سیستم");
                             }
                         }
                         else
                         {
                             MessageBox.Show("ظرفیت وارد شده بیش از حد است", "پیام سیستم");
                         }

                     }
                     else
                     {
                         if (CatRep.Add(view.Entity))
                         {
                             MessageBox.Show("دسته بندی  با موفقیت ثبت شد", "پیام سیستم");
                             treeControl.InitRoots();
                         }
                         else
                         {
                             MessageBox.Show("مشکل در ثبت دسته بندی به وجود آمد", "پیام سیستم");
                         }
                     }
                 }
             });
            AddAction("ویرایش", btn =>
            {
                var view = viewEngine.ViewInForm<view.ProductCategory.Editor>(editor =>
                {
                    if (treeControl.SelectedObject != null)
                        editor.Entity = treeControl.SelectedObject;
                    else
                        return;

                }, true);

                if (view.DialogResult == DialogResult.OK)
                {

                    if (view.Entity.SubProductCategoryID != 0)
                    {
                        var CapacityParent = CatRep.Find(view.Entity.SubProductCategoryID).Capacity;
                        List<Entities.ProductCategory> data = CatRep.GetByParent(view.Entity.SubProductCategoryID).ToList();
                        decimal count = 0;
                        foreach (var item in data)
                        {
                            count += item.Capacity;
                        }
                        var newcapacity = count + view.Entity.Capacity;
                        if (newcapacity <= CapacityParent)
                        {
                            if (CatRep.Update(view.Entity))
                            {
                                MessageBox.Show("دسته بندی با موفقیت ویرایش شد", "پیام سیستم");
                                treeControl.InitRoots();
                            }
                            else
                            {
                                MessageBox.Show("مشکل در ویرایش دسته بندی به وجود آمد", "پیام سیستم");
                            }
                        }
                        else
                        {
                            MessageBox.Show("ظرفیت وارد شده بیش از حد است", "پیام سیستم");
                        }
                    }
                    else
                    {
                        if (CatRep.Update(view.Entity))
                        {
                            MessageBox.Show("دسته بندی با موفقیت ویرایش شد", "پیام سیستم");
                            treeControl.InitRoots();
                        }
                        else
                        {
                            MessageBox.Show("مشکل در ویرایش دسته بندی به وجود آمد", "پیام سیستم");
                        }
                    }
                }
            });
            AddAction("حذف", btn =>
            {
                if (treeControl.SelectedObject == null)
                    return;
                if (MessageBox.Show("آیا میخواهید حذف کنید ؟", "پیام سیستم", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int dn = CatRep.CanDelete(treeControl.SelectedObject.ProductCategoryId);
                    if (dn != 0)
                        MessageBox.Show("این مورد به علت وابستگی به" + dn + "مواردامکان پاک شدن ندارد", "پیام سیستم");
                    else
                    {
                        if (CatRep.Delete(treeControl.SelectedObject.ProductCategoryId))
                        {
                            MessageBox.Show("دسته بندی با موفقیت حذف شد", "پیام سیستم");
                            treeControl.InitRoots();
                        }
                        else
                        {
                            MessageBox.Show("مشکل در دسته بندی به وجود آمد", "پیام سیستم");
                        }
                    }
                }
            });
            AddAction(" پارامتر ها", btn =>
            {
                if (treeControl.SelectedObject == null)
                    return;
                viewEngine.ViewInForm<view.ProductParameter.List>(editor =>
                {
                    editor.ParentCategoryId = treeControl.SelectedObject.ProductCategoryId;

                }, true);
            });

            treeControl = new TreeControl<Entities.ProductCategory>(this);
            treeControl.OnGetNode += TreeControl_OnGetNode;
            treeControl.InitRoots();
            base.OnLoad(e);
        }

        private IEnumerable<TreeControlNode<Entities.ProductCategory>> TreeControl_OnGetNode(TreeNode parent, Entities.ProductCategory obj)
        {
            List<TreeControlNode<Entities.ProductCategory>> nodes = new List<TreeControlNode<Entities.ProductCategory>>();
            if (parent == null)
            {
                var rootCategories = CatRep.GetByParent();
                return rootCategories.Select(cat => new TreeControlNode<Entities.ProductCategory>()
                {
                    Text = cat.Title,
                    Object = cat,
                });
            }
            else
            {
                var parentCategory = obj;
                var rootCategories = CatRep.GetByParent(parentCategory.ProductCategoryId);
                return rootCategories.Select(cat => new TreeControlNode<Entities.ProductCategory>()
                {
                    Text = cat.Title,
                    Object = cat,
                });
            }
        }
    }
}
