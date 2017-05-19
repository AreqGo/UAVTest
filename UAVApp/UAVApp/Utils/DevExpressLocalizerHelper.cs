using System;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraBars.Localization;
using DevExpress.XtraTreeList.Localization;
using DevExpress.XtraVerticalGrid.Localization;
using DevExpress.XtraLayout.Localization;
using DevExpress.XtraNavBar;

namespace UAVApp.Utils
{
    /// <summary>
    /// 汉化简化辅助类
    /// </summary>
    public class DevExpressLocalizerHelper {
        public static void SetSimpleChinese() {
            DevExpress.XtraGrid.Localization.GridLocalizer.Active = new XtraGridLocalizer_zh_chs();
            DevExpress.XtraGrid.Localization.GridResLocalizer.Active = new XtraGridLocalizer_zh_chs();
            DevExpress.XtraLayout.Localization.LayoutLocalizer.Active = new XtraLayoutLocalizer_zh_chs();
            DevExpress.XtraLayout.Localization.LayoutResLocalizer.Active = new XtraLayoutLocalizer_zh_chs();
            DevExpress.XtraEditors.Controls.Localizer.Active = new XtraEditorLocalizer_zh_chs();
            DevExpress.XtraBars.Localization.BarLocalizer.Active = new XtraBarsLocalizer_zh_chs();
            DevExpress.XtraBars.Localization.BarResLocalizer.Active = new XtraBarsLocalizer_zh_chs();
            DevExpress.XtraTreeList.Localization.TreeListLocalizer.Active = new XtraTreeListLocalizer_zh_chs();
            DevExpress.XtraTreeList.Localization.TreeListResLocalizer.Active = new XtraTreeListLocalizer_zh_chs();
            DevExpress.XtraVerticalGrid.Localization.VGridLocalizer.Active = new XtraVerticalGridLocalizer_zh_chs();
            DevExpress.XtraVerticalGrid.Localization.VGridResLocalizer.Active = new XtraVerticalGridLocalizer_zh_chs();
            DevExpress.XtraNavBar.NavBarLocalizer.Active = new NavBarLocalizer_zh_chs();
            DevExpress.XtraNavBar.NavBarResLocalizer.Active = new NavBarLocalizer_zh_chs();
        }
        public static String Language = "zh-chs";
    }


    public class XtraGridLocalizer_zh_chs : DevExpress.XtraGrid.Localization.GridLocalizer {
        public override string Language {
            get {
                return DevExpressLocalizerHelper.Language;
            }
        }
        public override string GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId id) {
            switch (id) {
                case GridStringId.FindControlFindButton: return "查找";
                case GridStringId.FindControlClearButton: return "清除";
                case GridStringId.FileIsNotFoundError: return "文件{0}找不到";
                case GridStringId.ColumnViewExceptionMessage: return " 要修正当前值吗?";
                case GridStringId.CustomizationCaption: return "自定义";
                case GridStringId.CustomizationColumns: return "列";
                case GridStringId.CustomizationBands: return "带宽";
                case GridStringId.PopupFilterAll: return "(全部)";
                case GridStringId.PopupFilterCustom: return "(自定义)";
                case GridStringId.PopupFilterBlanks: return "(空白)";
                case GridStringId.PopupFilterNonBlanks: return "(无空白)";
                case GridStringId.CustomFilterDialogFormCaption: return "用户自定义自动过滤器";
                case GridStringId.CustomFilterDialogCaption: return "显示符合下列条件的行:";
                case GridStringId.CustomFilterDialogRadioAnd: return "于(&A)";
                case GridStringId.CustomFilterDialogRadioOr: return "或(&O)";
                case GridStringId.CustomFilterDialogOkButton: return "确定(&O)";
                case GridStringId.CustomFilterDialogClearFilter: return "清除过滤器(&L)";
                case GridStringId.CustomFilterDialogCancelButton: return "取消(&C)";
                case GridStringId.CustomFilterDialog2FieldCheck: return "字段";
                case GridStringId.MenuFooterSum: return "和";
                case GridStringId.MenuFooterMin: return "最小值";
                case GridStringId.MenuFooterMax: return "最大值";
                case GridStringId.MenuFooterCount: return "计数";
                case GridStringId.MenuFooterAverage: return "平均值";
                case GridStringId.MenuFooterNone: return "无";
                case GridStringId.MenuFooterSumFormat: return "和={0:#.##}";
                case GridStringId.MenuFooterMinFormat: return "最小值={0}";
                case GridStringId.MenuFooterMaxFormat: return "最大值={0}";
                case GridStringId.MenuFooterCountFormat: return "{0}";
                case GridStringId.MenuFooterCountGroupFormat: return "计数={0}";
                case GridStringId.MenuFooterAverageFormat: return "平均={0:#.##}";
                case GridStringId.MenuFooterCustomFormat: return "统计值={0}";
                case GridStringId.MenuColumnSortAscending: return "升序排列";
                case GridStringId.MenuColumnSortDescending: return "降序排列";
                case GridStringId.MenuColumnClearSorting: return "清除排序设置";
                case GridStringId.MenuColumnGroup: return "根据此列分组";
                case GridStringId.FilterPanelCustomizeButton: return "自定义";
                case GridStringId.MenuColumnUnGroup: return "不分组";
                case GridStringId.MenuColumnColumnCustomization: return "列选择";
                case GridStringId.MenuColumnBestFit: return "最佳匹配";
                case GridStringId.MenuColumnFilter: return "允许筛选数据";
                case GridStringId.MenuColumnFilterEditor: return "设定数据筛选条件";
                case GridStringId.MenuColumnClearFilter: return "清除过滤器";
                case GridStringId.MenuColumnBestFitAllColumns: return "最佳匹配(所有列)";
                case GridStringId.MenuGroupPanelFullExpand: return "全部展开";
                case GridStringId.MenuGroupPanelFullCollapse: return "全部收合";
                case GridStringId.MenuGroupPanelClearGrouping: return "清除分组";
                case GridStringId.PrintDesignerBandedView: return "打印设置 (Banded View)";
                case GridStringId.PrintDesignerGridView: return "打印设置(网格视图)";
                case GridStringId.PrintDesignerCardView: return "打印设置(卡视图)";
                case GridStringId.PrintDesignerBandHeader: return "起始带宽";
                case GridStringId.PrintDesignerDescription: return "为当前视图设置不同的打印选项";
                case GridStringId.MenuColumnGroupBox: return "分组依据框";
                case GridStringId.CardViewNewCard: return "新建卡";
                case GridStringId.CardViewQuickCustomizationButton: return "自定义";
                case GridStringId.CardViewQuickCustomizationButtonFilter: return "过滤器　";
                case GridStringId.CardViewQuickCustomizationButtonSort: return "排序方式:";
                case GridStringId.GridGroupPanelText: return "拖动列标题至此,根据该列分组";
                case GridStringId.GridNewRowText: return "在此处添加一行";
                case GridStringId.FilterBuilderOkButton: return "确定(&O)";
                case GridStringId.FilterBuilderCancelButton: return "取消(&C)";
                case GridStringId.FilterBuilderApplyButton: return "应用(&A)";
                case GridStringId.FilterBuilderCaption: return "数据筛选条件设定：";
                case GridStringId.GridOutlookIntervals: return "更早;上个月;三周之前;两周之前;上周;;;;;;;;昨天;今天;明天;;;;;;;;下周;两周后;三周后;下个月;一个月之后;";
            }
            System.Diagnostics.Debug.WriteLine(id.ToString() + "的默认值(" + this.GetType().ToString() + ")=" + base.GetLocalizedString(id));
            return base.GetLocalizedString(id);
        }
    }

    public class XtraEditorLocalizer_zh_chs : DevExpress.XtraEditors.Controls.Localizer {
        public override string Language {
            get {
                return DevExpressLocalizerHelper.Language;
            }
        }

        public override string GetLocalizedString(DevExpress.XtraEditors.Controls.StringId id) {
            switch (id) {
                case StringId.PictureEditOpenFileFilter: return ";*.ico;*.位图文件 (*.bmp)|*.bmp|GIF文件 (*.gif)|*.gif|JPEG文件 (*.jpg;*.jpeg)|*.jpg;*.jpeg|Icon 文件 (*.ico)|*.ico|所有图像文件 |*.bmp;*.gif;*.jpg;*.jpeg;*.ico;*.png;*.tif|所有文件 |*.*";
                case StringId.NavigatorNextButtonHint: return "下一个";
                case StringId.ImagePopupPicture: return "(图像)";
                case StringId.TabHeaderButtonNext: return "向右滚动";
                case StringId.TabHeaderButtonPrev: return "向左滚动";
                case StringId.XtraMessageBoxOkButtonText: return "确定(&O)";
                case StringId.Cancel: return "取消(&C)l";
                case StringId.DateEditToday: return "今天";
                case StringId.DateEditClear: return "清除";
                case StringId.PictureEditMenuCut: return "剪切";
                case StringId.NavigatorEditButtonHint: return "编辑";
                case StringId.TextEditMenuCut: return "剪切(&t)";
                case StringId.ImagePopupEmpty: return "(空)";
                case StringId.NavigatorNextPageButtonHint: return "下一页";
                case StringId.NavigatorTextStringFormat: return "记录 {0} of {1}";
                case StringId.CaptionError: return "错误";
                case StringId.XtraMessageBoxNoButtonText: return "否(&N)";
                case StringId.PictureEditOpenFileTitle: return "打开";
                case StringId.PictureEditOpenFileError: return "错误的图像格式";
                case StringId.XtraMessageBoxIgnoreButtonText: return "忽略(&I)";
                case StringId.NavigatorRemoveButtonHint: return "删除";
                case StringId.TabHeaderButtonClose: return "关闭";
                case StringId.CheckUnchecked: return "非校验";
                case StringId.PictureEditSaveFileFilter: return "位图文件 (*.bmp)|*.bmp|GIF文件 (*.gif)|*.gif|JPEG 文件 (*.jpg)|*.jpg";
                case StringId.TextEditMenuSelectAll: return "全选(&A)";
                case StringId.PictureEditSaveFileTitle: return "另存为";
                case StringId.DataEmpty: return "没有图像数据";
                case StringId.XtraMessageBoxAbortButtonText: return "中断(&A)";
                case StringId.CheckIndeterminate: return "不确定";
                case StringId.NavigatorLastButtonHint: return "最后一个";
                case StringId.TextEditMenuCopy: return "复制(&C)";
                case StringId.TextEditMenuUndo: return "撤销(&U)";
                case StringId.CalcError: return "计算错误";
                case StringId.CalcButtonBack: return "后退";
                case StringId.CalcButtonSqrt: return "平方根";
                case StringId.LookUpColumnDefaultName: return "名称";
                case StringId.NavigatorEndEditButtonHint: return "结束编辑";
                case StringId.NotValidArrayLength: return "无效的数组长度。";
                case StringId.ColorTabWeb: return "网页";
                case StringId.PictureEditMenuSave: return "保存";
                case StringId.PictureEditMenuCopy: return "复制";
                case StringId.PictureEditMenuLoad: return "调用";
                case StringId.NavigatorFirstButtonHint: return "第一个";
                case StringId.MaskBoxValidateError: return @"输入值不完整,是否修正?
	
	
	是 - 返回编辑器,修正该值.
	否 -保留该值.
	取消 - 重设为原来的值.";
                case StringId.UnknownPictureFormat: return "未知的图形格式";
                case StringId.NavigatorPreviousPageButtonHint: return "前一页";
                case StringId.XtraMessageBoxRetryButtonText: return "重试(&R)";
                case StringId.LookUpEditValueIsNull: return "[编辑值为空]";
                case StringId.CalcButtonC: return "C";
                case StringId.XtraMessageBoxCancelButtonText: return "取消(&C)l";
                case StringId.LookUpInvalidEditValueType: return "无效的 LookUpEdit 编辑值类型。";
                case StringId.NavigatorAppendButtonHint: return "追加";
                case StringId.CalcButtonMx: return "M+";
                case StringId.CalcButtonMC: return "MC";
                case StringId.CalcButtonMS: return "MS";
                case StringId.CalcButtonMR: return "MR";
                case StringId.CalcButtonCE: return "CE";
                case StringId.NavigatorCancelEditButtonHint: return "取消编辑";
                case StringId.PictureEditOpenFileErrorCaption: return "打开错误";
                case StringId.OK: return "确定(&O)";
                case StringId.CheckChecked: return "校验";
                case StringId.TextEditMenuPaste: return "粘贴(&P)";
                case StringId.TextEditMenuDelete: return "删除(&D)";
                case StringId.ColorTabSystem: return "系统";
                case StringId.PictureEditMenuPaste: return "粘贴";
                case StringId.XtraMessageBoxYesButtonText: return "是(&Y)";
                case StringId.InvalidValueText: return "无效值";
                case StringId.PictureEditMenuDelete: return "删除";
                case StringId.NavigatorPreviousButtonHint: return "前一个";
                case StringId.ColorTabCustom: return "自定义";
            }
            System.Diagnostics.Debug.WriteLine(id.ToString() + "的默认值(" + this.GetType().ToString() + ")=" + base.GetLocalizedString(id));
            return base.GetLocalizedString(id);
        }
    }

    public class XtraBarsLocalizer_zh_chs : DevExpress.XtraBars.Localization.BarLocalizer {
        public override string Language {
            get {
                return DevExpressLocalizerHelper.Language;
            }
        }

        public override string GetLocalizedString(DevExpress.XtraBars.Localization.BarString id) {
            switch (id) {
                case BarString.AddOrRemove: return "添加或删除按钮(&A)";
                case BarString.ResetBar: return "确定要对 '{0}' 工具栏所做的改动进行重置吗？";
                case BarString.ResetBarCaption: return "自定义";
                case BarString.ResetButton: return "重设工具栏(&R)";
                case BarString.CustomizeButton: return "自定义...(&C)";
                case BarString.ToolBarMenu: return "重新设定(&R)$刪除(&D)$!重新命名(&N)$!默认格式(&L)$全文字模式(&T)$文字菜单(&O)$图片及文字(&A)$!启用组(&G)$可见的(&V)$最近使用的(&M)";
                case BarString.NewToolbarName: return "工具";
                case BarString.NewMenuName: return "主菜单";
                case BarString.NewStatusBarName: return "状态栏";
                case BarString.NewToolbarCustomNameFormat: return "自定义{0}";
                case BarString.NewToolbarCaption: return "新建工具栏";
                case BarString.RenameToolbarCaption: return "重命名工具栏";
                case BarString.CustomizeWindowCaption: return "自定义";
                case BarString.MenuAnimationSystem: return "(系统默认值)";
                case BarString.MenuAnimationNone: return "无";
                case BarString.MenuAnimationSlide: return "片";
                case BarString.MenuAnimationFade: return "减弱";
                case BarString.MenuAnimationUnfold: return "展开";
                case BarString.MenuAnimationRandom: return "随机";
                case BarString.PopupMenuEditor: return "弹出菜单编辑器";
                case BarString.ToolbarNameCaption: return "工具栏名称(&T)";
                case BarString.RibbonToolbarBelow: return "将快速访问工具栏显示在功能区下方(&S)";
                case BarString.RibbonToolbarAbove: return "将快速访问工具栏显示在功能区上方(&S)";
                case BarString.RibbonToolbarRemove: return "移除快速访问工具栏(&R)";
                case BarString.RibbonToolbarAdd: return "添加快速访问工具栏(&A)";
                case BarString.RibbonToolbarMinimizeRibbon: return "最小化功能区(&N)";
                case BarString.RibbonGalleryFilter: return "所有组";
                case BarString.RibbonGalleryFilterNone: return "无";
                case BarString.BarUnassignedItems: return "(未设定项)";
                case BarString.BarAllItems: return "(所有项)";
                case BarString.RibbonUnassignedPages: return "(未设定页)";
                case BarString.RibbonAllPages: return "(所有页)";
            }
            System.Diagnostics.Debug.WriteLine(id.ToString() + "的默认值(" + this.GetType().ToString() + ")=" + base.GetLocalizedString(id));
            return base.GetLocalizedString(id);
        }

    }

    public class XtraTreeListLocalizer_zh_chs : DevExpress.XtraTreeList.Localization.TreeListLocalizer {
        public override string Language {
            get {
                return DevExpressLocalizerHelper.Language;
            }
        }
        public override string GetLocalizedString(DevExpress.XtraTreeList.Localization.TreeListStringId id) {
            switch (id) {
                case TreeListStringId.MenuColumnBestFit: return "最佳匹配";
                case TreeListStringId.PrintDesignerHeader: return "打印设置";
                case TreeListStringId.ColumnCustomizationText: return "自定义";
                case TreeListStringId.MenuFooterMin: return "最小值";
                case TreeListStringId.MenuFooterMax: return "最大值";
                case TreeListStringId.MenuFooterSum: return "和";
                case TreeListStringId.MenuFooterAllNodes: return "所有节点";
                case TreeListStringId.MenuFooterCount: return "计数";
                case TreeListStringId.MenuColumnSortAscending: return "升序排列";
                case TreeListStringId.MenuFooterNone: return "无";
                case TreeListStringId.MenuColumnSortDescending: return "降序排列";
                case TreeListStringId.PrintDesignerDescription: return "为当前的树状列表设置不同的打印选项";
                case TreeListStringId.MenuColumnBestFitAllColumns: return "最佳匹配 (所有列)";
                case TreeListStringId.MenuFooterAverageFormat: return "平均值={0:#.##}";
                case TreeListStringId.ColumnNamePrefix: return "列";
                case TreeListStringId.MenuFooterMinFormat: return "最小值={0}";
                case TreeListStringId.MenuFooterCountFormat: return "{0}";
                case TreeListStringId.MenuColumnColumnCustomization: return "列选择";
                case TreeListStringId.MenuFooterMaxFormat: return "最大值={0}";
                case TreeListStringId.MenuFooterSumFormat: return "和={0:#.##}";
                case TreeListStringId.MultiSelectMethodNotSupported: return "OptionsBehavior.MultiSelect未激活时，指定方法不能工作.";
                case TreeListStringId.InvalidNodeExceptionText: return " 要修正当前值吗?";
                case TreeListStringId.MenuFooterAverage: return "平均值";
            }
            System.Diagnostics.Debug.WriteLine(id.ToString() + "的默认值(" + this.GetType().ToString() + ")=" + base.GetLocalizedString(id));
            return base.GetLocalizedString(id);
        }
    }

    public class XtraVerticalGridLocalizer_zh_chs : DevExpress.XtraVerticalGrid.Localization.VGridLocalizer {
        public override string Language {
            get {
                return DevExpressLocalizerHelper.Language;
            }
        }
        public override string GetLocalizedString(DevExpress.XtraVerticalGrid.Localization.VGridStringId id) {
            switch (id) {
                case VGridStringId.RowCustomizationText: return "定制";
                case VGridStringId.RowCustomizationNewCategoryFormText: return "新增数据类别";
                case VGridStringId.RowCustomizationNewCategoryFormLabelText: return "标题：";
                case VGridStringId.RowCustomizationNewCategoryText: return "新增";
                case VGridStringId.RowCustomizationDeleteCategoryText: return "删除";
                case VGridStringId.InvalidRecordExceptionText: return "是否要修改不正确的数据值？";
                case VGridStringId.RowCustomizationTabPageCategoriesText: return "分类数据";
                case VGridStringId.RowCustomizationTabPageRowsText: return "数据列";
                case VGridStringId.StyleCreatorName: return "风格定制器";
            }
            System.Diagnostics.Debug.WriteLine(id.ToString() + "的默认值(" + this.GetType().ToString() + ")=" + base.GetLocalizedString(id));
            return base.GetLocalizedString(id);
        }
    }

    public class XtraLayoutLocalizer_zh_chs : DevExpress.XtraLayout.Localization.LayoutLocalizer {
        public override string Language {
            get {
                return DevExpressLocalizerHelper.Language;
            }
        }
        public override string GetLocalizedString(DevExpress.XtraLayout.Localization.LayoutStringId id) {
            switch (id) {
                case LayoutStringId.CustomizationParentName: return "定制";
                case LayoutStringId.DefaultItemText: return "项目";
                case LayoutStringId.DefaultActionText: return "默认动作";
                case LayoutStringId.DefaultEmptyText: return "无";
                case LayoutStringId.LayoutItemDescription: return "版面设计控制器的项目元素";
                case LayoutStringId.LayoutGroupDescription: return "版面设计控制器的群组元素";
                case LayoutStringId.TabbedGroupDescription: return "版面控制器的群组标签页元素";
                case LayoutStringId.LayoutControlDescription: return "版面控制";
                case LayoutStringId.CustomizationFormTitle: return "定制";
                case LayoutStringId.TreeViewPageTitle: return "版面设计树状视图";
                case LayoutStringId.HiddenItemsPageTitle: return "隐藏项目";
                case LayoutStringId.RenameSelected: return "重命名";
                case LayoutStringId.HideItemMenutext: return "隐藏项目";
                case LayoutStringId.LockItemSizeMenuText: return "锁定项目大小";
                case LayoutStringId.UnLockItemSizeMenuText: return "解除项目大小锁定";
                case LayoutStringId.GroupItemsMenuText: return "群组";
                case LayoutStringId.UnGroupItemsMenuText: return "解除群组设定";
                case LayoutStringId.CreateTabbedGroupMenuText: return "创建群组标签页";
                case LayoutStringId.AddTabMenuText: return "增加标签页";
                case LayoutStringId.UnGroupTabbedGroupMenuText: return "解除群组标签页设定";
                case LayoutStringId.TreeViewRootNodeName: return "最上层";
                case LayoutStringId.ShowCustomizationFormMenuText: return "定制版面";
                case LayoutStringId.HideCustomizationFormMenuText: return "隐藏定制表格";
                case LayoutStringId.EmptySpaceItemDefaultText: return "空白区域项目";
                case LayoutStringId.SplitterItemDefaultText: return "分隔器版面設計控制器的群組標籤頁項目";
                case LayoutStringId.ControlGroupDefaultText: return "群组";
                case LayoutStringId.EmptyRootGroupText: return "在这里放置控件";
                case LayoutStringId.EmptyTabbedGroupText: return "将群组拖放到群组标签页区域";
                case LayoutStringId.ResetLayoutMenuText: return "重设版面";
                case LayoutStringId.RenameMenuText: return "重命名";
                case LayoutStringId.TextPositionMenuText: return "文本位置";
                case LayoutStringId.TextPositionLeftMenuText: return "左边";
                case LayoutStringId.TextPositionRightMenuText: return "右边";
                case LayoutStringId.TextPositionTopMenuText: return "上方";
                case LayoutStringId.TextPositionBottomMenuText: return "下方";
                case LayoutStringId.ShowTextMenuItem: return "显示文本";
                case LayoutStringId.HideTextMenuItem: return "隐藏文本";
                case LayoutStringId.LockSizeMenuItem: return "锁定大小";
                case LayoutStringId.LockWidthMenuItem: return "锁定宽度";
                case LayoutStringId.CreateEmptySpaceItem: return "创建空白区域项目";
                case LayoutStringId.LockHeightMenuItem: return "锁定高度";
                case LayoutStringId.LockMenuGroup: return "强制限定大小";
                case LayoutStringId.FreeSizingMenuItem: return "允许改变大小";
                case LayoutStringId.ResetConstraintsToDefaultsMenuItem: return "重设为默认值";
            }
            System.Diagnostics.Debug.WriteLine(id.ToString() + "的默认值(" + this.GetType().ToString() + ")=" + base.GetLocalizedString(id));
            return base.GetLocalizedString(id);
        }
    }

    public class NavBarLocalizer_zh_chs : DevExpress.XtraNavBar.NavBarLocalizer {
        public override string Language {
            get {
                return DevExpressLocalizerHelper.Language;
            }
        }
        public override string GetLocalizedString(DevExpress.XtraNavBar.NavBarStringId id) {
            switch (id) {
                case NavBarStringId.NavPaneMenuAddRemoveButtons: return "添加或删除按钮（&A）";
                case NavBarStringId.NavPaneMenuShowMoreButtons: return "显示更多按钮（&M）";
                case NavBarStringId.NavPaneChevronHint: return "配置按钮";
                case NavBarStringId.NavPaneMenuShowFewerButtons: return "显示少量按钮（&F）";
            }
            System.Diagnostics.Debug.WriteLine(id.ToString() + "的默认值(" + this.GetType().ToString() + ")=" + base.GetLocalizedString(id));
            return base.GetLocalizedString(id);
        }
    }
}
